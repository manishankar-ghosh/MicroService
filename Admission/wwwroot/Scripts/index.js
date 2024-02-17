async function getAllStudents() {
    const response = await fetch("https://localhost:7138/api/Admissions");
    const students = await response.json();

    students.forEach(x => {
        let utcDate = new Date(x.doa);
        let offsetMinutes = utcDate.getTimezoneOffset();
        let localTime = new Date(utcDate.getTime() - offsetMinutes * 60 * 1000);
        let utcDateStr = `${utcDate.toDateString()} ${utcDate.toLocaleTimeString()}`;
        let localDateStr = `${localTime.toDateString()} ${localTime.toLocaleTimeString()}`;
        console.log(`${x.name}: UTC->${utcDateStr}, Local->${localDateStr}`);
        //console.log(`${localTime.toDateString()} ${localTime.toLocaleTimeString()}`);
    });

    //for (let x in students) {
    //    console.log(x);
    //}
}