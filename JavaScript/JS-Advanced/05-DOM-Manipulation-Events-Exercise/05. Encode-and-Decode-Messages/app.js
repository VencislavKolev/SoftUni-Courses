function encodeAndDecodeMessages() {
    let encodeBtn = document.getElementsByTagName('button')[0];
    let decodeBtn = document.getElementsByTagName('button')[1];
    let textArea1 = document.getElementsByTagName('textarea')[0];
    let textArea2 = document.getElementsByTagName('textarea')[1];

    encodeBtn.addEventListener('click', onSendEventHandler);
    decodeBtn.addEventListener('click', onDecodeEventHandler)

    function onSendEventHandler(e) {
        let encoded = '';
        for (let i = 0; i < textArea1.value.length; i++) {
            encoded += String.fromCharCode(textArea1.value.charCodeAt(i) + 1);
        }
        textArea1.value = '';
        console.log(encoded);
        textArea2.value = encoded;
    }

    function onDecodeEventHandler(e) {
        let decoded = '';
        for (let i = 0; i < textArea2.value.length; i++) {
            decoded += String.fromCharCode(textArea2.value.charCodeAt(i) - 1);
        }
        textArea2.readOnly = true;
        textArea2.value = decoded;
    }
}