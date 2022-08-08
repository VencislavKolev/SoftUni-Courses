function roadRadar(speed, area) {
    let residential = 20;
    let city = 50;
    let interstate = 90;
    let motorway = 130;

    let diff;
    let limit;
    let isOverLimit;

    switch (area) {
        case 'city':
            isOverLimit = speed > city
            diff = speed - city
            limit = city;
            break;
        case 'residential':
            isOverLimit = speed > residential
            diff = speed - residential
            limit = residential;
            break;
        case 'interstate':
            isOverLimit = speed > interstate
            diff = speed - interstate
            limit = interstate;
            break;
        case 'motorway':
            isOverLimit = speed > motorway
            diff = speed - motorway
            limit = motorway;
            break;
    }

    if (isOverLimit) {
        let status;
        if (diff <= 20) status = 'speeding';
        else if (diff <= 40) status = 'excessive speeding';
        else if (diff > 40) status = 'reckless driving';
        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${limit} - ${status}`);
    } else {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
}

roadRadar(40, 'city')
roadRadar(21, 'residential')
roadRadar(200, 'motorway')