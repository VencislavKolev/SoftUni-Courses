function sum(arr, start, end) {
    if (!Array.isArray(arr)) {
        return NaN;
    }
    const startIdx = Math.max(start, 0);
    const endIdx = Math.min(end, arr.length - 1);

    return arr
        .slice(startIdx, endIdx + 1)
        .reduce((acc, curr) => {
            return acc += Number(curr)
        }, 0)
}

sum([10, 20, 30, 40, 50, 60], 3, 300)