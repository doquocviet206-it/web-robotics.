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

        initSearchSuggestions();
    });

    function initSearchSuggestions() {
        const inputs = document.querySelectorAll('input[data-search-suggest="true"]');
        if (!inputs.length) return;

        inputs.forEach((input) => {
            const wrapper = input.closest('.search-suggest-wrapper') || input.parentElement;
            if (!wrapper) return;

            const menu = document.createElement('div');
            menu.className = 'search-suggest-menu';
            menu.setAttribute('role', 'listbox');
            wrapper.appendChild(menu);

            let debounceTimer = null;
            let activeIndex = -1;
            let lastRequestId = 0;

            const closeMenu = () => {
                menu.classList.remove('show');
                activeIndex = -1;
            };

            const escapeText = (value) => {
                const div = document.createElement('div');
                div.textContent = value ?? '';
                return div.innerHTML;
            };

            const renderMenu = (items, query) => {
                menu.innerHTML = '';
                activeIndex = -1;

                if (!items.length && !query) {
                    closeMenu();
                    return;
                }

                const header = document.createElement('div');
                header.className = 'search-suggest-header';
                header.textContent = query ? 'Gợi ý phù hợp' : 'Tìm kiếm phổ biến';
                menu.appendChild(header);

                if (items.length === 0) {
                    const empty = document.createElement('div');
                    empty.className = 'px-3 py-2 text-secondary fs-xs';
                    empty.textContent = 'Không có gợi ý nhanh phù hợp.';
                    menu.appendChild(empty);
                } else {
                    items.forEach((item) => {
                        const link = document.createElement('a');
                        link.className = 'search-suggest-item';
                        link.href = item.url;
                        link.setAttribute('role', 'option');
                        link.innerHTML = `
                            <span class="search-suggest-title">
                                <i class="bi ${escapeText(item.icon || 'bi-search')} text-cyan"></i>
                                <span>${escapeText(item.title)}</span>
                            </span>
                            <span class="search-suggest-badge">${escapeText(item.category)}</span>
                        `;
                        menu.appendChild(link);
                    });
                }

                if (query) {
                    const footer = document.createElement('a');
                    footer.className = 'search-suggest-footer';
                    footer.href = `/Search?q=${encodeURIComponent(query)}`;
                    footer.setAttribute('role', 'option');
                    footer.innerHTML = `<i class="bi bi-search"></i><span>Tìm tất cả kết quả cho "${escapeText(query)}"</span>`;
                    menu.appendChild(footer);
                }

                menu.classList.add('show');
            };

            const fetchSuggestions = async () => {
                const query = input.value.trim();
                const requestId = ++lastRequestId;
                try {
                    const res = await fetch(`/Search/Suggest?q=${encodeURIComponent(query)}`);
                    if (!res.ok || requestId !== lastRequestId) return;
                    const items = await res.json();
                    renderMenu(Array.isArray(items) ? items : [], query);
                } catch {
                    closeMenu();
                }
            };

            input.addEventListener('focus', () => {
                fetchSuggestions();
            });

            input.addEventListener('input', () => {
                clearTimeout(debounceTimer);
                debounceTimer = setTimeout(fetchSuggestions, 180);
            });

            input.addEventListener('keydown', (e) => {
                if (!menu.classList.contains('show')) return;
                const options = menu.querySelectorAll('[role="option"]');
                if (!options.length) return;

                if (e.key === 'ArrowDown') {
                    e.preventDefault();
                    activeIndex = (activeIndex + 1) % options.length;
                } else if (e.key === 'ArrowUp') {
                    e.preventDefault();
                    activeIndex = (activeIndex - 1 + options.length) % options.length;
                } else if (e.key === 'Enter' && activeIndex >= 0) {
                    e.preventDefault();
                    options[activeIndex].click();
                    return;
                } else if (e.key === 'Escape') {
                    closeMenu();
                    return;
                } else {
                    return;
                }

                options.forEach((opt, idx) => {
                    opt.classList.toggle('active', idx === activeIndex);
                });
            });

            document.addEventListener('click', (e) => {
                if (!wrapper.contains(e.target)) {
                    closeMenu();
                }
            });
        });
    }
})();
