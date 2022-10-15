function lockedProfile() {
    let showMoreButtons = Array.from(document.querySelectorAll('button'));
    showMoreButtons.forEach(btn => {
        btn.addEventListener('click', showMoreEventHandler)
    })

    function showMoreEventHandler(e) {
        let profile = e.target.parentElement;
        let isLocked = profile.querySelector('input[value=lock]').checked;
        let hiddenDiv = profile.querySelector('div');

        if (!isLocked) {
            if (e.target.textContent === 'Show more') {
                hiddenDiv.style.display = 'block';
                e.target.textContent = 'Hide it'
            } else {
                hiddenDiv.style.display = 'none';
                e.target.textContent = 'Show more'
            }
        }
    }
}