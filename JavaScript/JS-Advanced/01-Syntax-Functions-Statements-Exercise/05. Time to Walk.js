function timeToWalk(steps, footPrintInMeters, speedKph) {
    let distance = steps * footPrintInMeters;
    let breakTime = Math.floor(distance / 500) * 60;
    let speed = speedKph * 1000 / 3600;
    let time = distance / speed + breakTime;

    let hours = Math.floor(time / 3600)
    let min = Math.floor(time / 60)
    let sec = Math.round(time % 60);

    if (hours < 10) {
        hours = "0" + hours
    }
    if (min < 10) {
        min = "0" + min
    }
    if (sec < 10) {
        sec = "0" + sec
    }

    console.log(`${hours}:${min}:${sec}`);
}

timeToWalk(4000, 0.60, 5)
timeToWalk(2564, 0.70, 5.5)