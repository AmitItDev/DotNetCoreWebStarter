// /js/tabulator-helper.js

const TabulatorHelper = (() => {
    // Default Localization Settings (Change per project)
    const config = {
        currencyLocale: "en-ZA", //  South Africa default (update here for other regions)
        currencyCode: "ZAR"
    };


    // Date formatting options - modify here as per project needs
    // Common formats:
    // 1. Numeric short: MM/dd/yyyy  --> e.g. 12/11/2025
    // 2. Numeric long: dd/MM/yyyy   --> e.g. 11/12/2025
    // 3. Verbose: 11 Dec 2025       --> day month year with short month name
    // 4. Full date: Friday, 11 December 2025
    //
    // Customize the options below to change the output format globally.
    const locale = 'en-ZA';
    const dateFormatOptions = {
        year: 'numeric',
        month: 'short', // change to 'numeric' for MM/dd/yyyy, or 'long' for full month name
        day: '2-digit', // 'numeric' or '2-digit'
        // weekday: 'long', // uncomment for full weekday name
    };

    function formatDate(cell) {
        const date = cell.getValue();
        if (!date) return "";
        // Parse the date if necessary (assuming ISO format from server)
        const d = new Date(date);
        return d.toLocaleDateString(locale, dateFormatOptions);
    }

    // Alignment logic
    function getDefaultAlign(field) {
        if (/amount|price|rate|total|number|qty/i.test(field)) return "right";
        if (/date|time/i.test(field)) return "center";
        return "left";
    }

    // Currency formatter
    function formatCurrency(cell) {
        const val = parseFloat(cell.getValue());
        return isNaN(val)
            ? ""
            : val.toLocaleString(config.currencyLocale, {
                style: "currency",
                currency: config.currencyCode,
                minimumFractionDigits: 2
            });
    }

    // Status badge formatter
    function formatStatus(cell) {
        const status = cell.getValue();
        const color = status === "Active"
            ? "bg-[#00aeef] text-white"
            : "bg-gray-300 text-gray-800";
        return `<span class="px-2 py-1 text-xs rounded-full font-semibold ${color}">${status}</span>`;
    }

    // Reusable table initializer
    function initTable(selector, columns, options = {}) {
        const defaultOptions = {
            layout: "fitColumns",
            autoResize: true,
            responsiveLayout: true,
            tooltips: true,
            headerSort: false,
            pagination: true,
            paginationMode: "remote",
            paginationSize: 10,
            paginationSizeSelector: [10, 25, 50, 100],
            movableColumns: true,
            resizableRows: false,
            placeholder: "No data found.",
            height: "auto",
            rowFormatter: function (row) {
                const el = row.getElement();
                el.classList.add("transition", "duration-200", "hover:bg-blue-50", "text-sm");
                if (row.getPosition() % 2 === 1) {
                    el.classList.add("bg-gray-50");
                } else {
                    el.classList.remove("bg-gray-50");
                }
            }
        };

        // Apply default alignments if not explicitly defined
        const formattedColumns = columns.map(col => ({
            ...col,
            hozAlign: col.hozAlign || getDefaultAlign(col.field || "")
        }));

        return new Tabulator(selector, {
            ...defaultOptions,
            ...options,
            columns: formattedColumns
        });
    }

    // Optional: function to override config dynamically
    function setLocaleAndCurrency(locale, currency) {
        config.currencyLocale = locale;
        config.currencyCode = currency;
    }

    return {
        initTable,
        formatCurrency,
        formatDate,
        formatStatus,
        setLocaleAndCurrency,
        config // expose config if needed externally
    };
})();
