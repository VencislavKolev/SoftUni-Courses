function editElement(element, match, replacer) {
    // while(element.textContent.includes(match)){
    //     element.textContent = element.textContent.replace(match, replacer)
    // }

    let regex = new RegExp(match, 'g');
    element.textContent = element.textContent.replace(regex, replacer);
}