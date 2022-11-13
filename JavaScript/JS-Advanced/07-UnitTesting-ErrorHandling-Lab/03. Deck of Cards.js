function printDeckOfCards(cards) {
    let result = [];
    for (const card of cards) {
        try {
            let start = 0;
            let end = card.length == 3 ? 2 : 1;
            let createdCard = createCard(card.substring(start, end), card.substring(end));
            result.push(createdCard);
        } catch (error) {
            result.push(error.message);
        }
    }
    console.log(result.join(' '));

    function createCard(face, suit) {
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const validSuits = { 'S': '\u2660', 'H': '\u2665', 'D': '\u2666', 'C': '\u2663' };

        if (!validFaces.includes(face) || !Object.keys(validSuits).includes(suit)) {
            throw new Error(`Invalid card: ${face}${suit}`);
        }

        return `${face}${validSuits[suit]}`;
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C'])
printDeckOfCards(['5S', '3D', 'QD', '1C'])