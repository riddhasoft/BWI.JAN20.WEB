//whil// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict'
var userName = "binod";

var age = 35;



age = 35 + '4';//text
age = parseInt(age) + 4;//text
var condition = 2 === '2'

for (var i = 0; i < 5; i++) {
    console.log(i);
}
var i = 0;
while (i <= 5) {

    console.log(i);
    i++;
}

var students = ['dip', 'prabin'];

students.push('brijesh');
students.push(356);
students.push({
    id: 25,
    name: 'Binod'
});

//students.pop();

let index = students.at('dip');
students.splice(index, 1);
for (var i in students) {
    console.log(students[i]);
}




//string functionName(){

//}

function functionA() {
    console.log('function a')
}

var functionB = function () {
    console.log('function b')

    var functionC = () => {
        console.log('function c')
    }

    functionC();
    return 'funcitonB';




}


//js literals
var student = {
    id: 1,
    name: 'binod',
    address: 'tokha'

};
console.log(student);

//modules in js
var studentModel = function () {
    this.id = 0;
    this.name = '';
    this.address = '';

}

var interestModel = function () {
    var n = 5;
    var rate = 0.15;
    this.priciple = 100000;

    this.calculateInterest = function () {
        return this.priciple * n * rate / 100;
    }

}
var $$ = interestModel;


function checkEvent() {
    alert('event triggered')
}
function mouseTrack() {
    console.log('mouse ')
}

function clickEvent() {
    alert('clicked')
}