function createSortedList() {
    return {
        list: [],
        size: 0,
        add: function (element) {
            this.list.push(element);
            this.size++;
            this.sort();
        },
        remove: function (index) {
            if (index >= 0 && index < this.list.length) {
                this.list.splice(index, 1);
                this.size--;
            }
        },
        get: function (index) {
            if (index >= 0 && index < this.list.length) {
                return this.list[index];
            }
        },
        sort: function () {
            this.list.sort((a, b) => a - b);
        }
    }
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));