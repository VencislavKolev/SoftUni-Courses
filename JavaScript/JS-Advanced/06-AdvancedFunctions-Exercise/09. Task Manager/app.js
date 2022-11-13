function solve() {
    let addBtn = document.getElementById('add');
    // let sections = document.querySelectorAll('section');
    let secondDivInSections = document.querySelectorAll('section div:nth-child(2n)');
    // console.log(secondDivInSections);

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        // console.log(e.target.parentElement)
        let inputFields = Array.from(e.target.parentElement.querySelectorAll('input[type=text], textarea'));
        // console.log(inputFields);
        if (inputFields.every(x => x.value != '')) {
            let article = document.createElement('article');

            let h3 = document.createElement('h3');
            h3.textContent = inputFields[0].value;
            let p1 = document.createElement('p');
            p1.textContent = inputFields[1].value;
            let p2 = document.createElement('p');
            p2.textContent = inputFields[2].value;

            let div = document.createElement('div');
            div.className = "flex";

            let startBtn = document.createElement('button');
            startBtn.className = "green";
            startBtn.textContent = "Start";
            startBtn.addEventListener('click', function (e) {
                e.target.className = "orange";
                e.target.textContent = "Finish";
                // e.target.parentElement.children
                secondDivInSections[2].appendChild(e.target.parentElement.parentElement);
                e.target.addEventListener('click', function (e) {
                    secondDivInSections[3].appendChild(e.target.parentElement.parentElement);
                    e.target.parentElement.remove();
                })
            });

            let deleteBtn = document.createElement('button');
            deleteBtn.className = "red";
            deleteBtn.textContent = "Delete";
            deleteBtn.addEventListener('click', function (e) {
                e.target.parentElement.parentElement.remove();
            });

            div.append(startBtn, deleteBtn);

            article.append(h3, p1, p2, div);

            secondDivInSections[1].appendChild(article);
            // console.log(sections[1].querySelectorAll('div')[1])
        }
    })
}