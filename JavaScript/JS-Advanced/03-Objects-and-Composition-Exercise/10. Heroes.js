function solve() {
    const HUNDRED = 100;
    return {
        mage: function (name) {
            let mage = {
                name: name,
                health: HUNDRED,
                mana: HUNDRED,
                cast: function (spell) {
                    this.mana--;
                    console.log(`${this.name} cast ${spell}`);
                }
            }
            return mage;
        },
        fighter: function (name) {
            let fighter = {
                name: name,
                health: HUNDRED,
                stamina: HUNDRED,
                fight: function () {
                    this.stamina--;
                    console.log(`${this.name} slashes at the foe!`);
                }
            }
            return fighter;
        }
    }
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);