function kNumbers(n, k) {
    let sequence = [1];
    while (sequence.length != n) {
        let sum = 0;
        let start = 0;
        if (sequence.length >= k) {
            start = sequence.length - k;
        }
        for (let i = start; i < sequence.length; i++) {
            const element = sequence[i];
            sum += element;
        }
        sequence.push(sum);
    }
    console.log(sequence);
    // return sequence;
}

kNumbers(6, 3)
kNumbers(8, 2)