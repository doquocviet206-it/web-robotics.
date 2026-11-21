(() => {
    const storageKey = 'robolab-theme';
    const root = document.documentElement;

    try {
        const savedTheme = localStorage.getItem(storageKey);
        if (savedTheme === 'light' || savedTheme === 'dark') {
            root.dataset.bsTheme = savedTheme;
        }
    } catch {
        // The page still supports switching themes when storage is unavailable.
    }

    document.addEventListener('DOMContentLoaded', () => {
        document.getElementById('theme-toggle')?.addEventListener('click', () => {
            const theme = root.dataset.bsTheme === 'light' ? 'dark' : 'light';
            root.dataset.bsTheme = theme;

            try {
                localStorage.setItem(storageKey, theme);
            } catch {
                // The theme has already been applied to the current page.
            }
        });
    });
})();
