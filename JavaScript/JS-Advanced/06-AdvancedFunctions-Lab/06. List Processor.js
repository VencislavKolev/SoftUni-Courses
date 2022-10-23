function solve(commands) {
    function listProcessorBuilder() {
        let list = [];
        return {
            add: (item) => list.push(item),
            remove: (item) => list = list.filter(x => x != item),
            print: () => console.log(list.join(','))
        }
    }
    const listProcessor = listProcessorBuilder();
    commands.map(x => x.split(' '))
        .forEach(([command, argument]) => listProcessor[command](argument));
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print'])