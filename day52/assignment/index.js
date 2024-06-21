// Object persion
console.log("object person")
class Person {
    constructor(name, age, city, grade) {
        this.name = name;
        this.age = age;
        this.city = city;
        this.grade = grade;
    }
    displayDetails() {
        return `Name: ${this.name}, Age: ${this.age}, City: ${this.city}, Grade: ${this.grade}`;
    }
}


const person1 = new Person('John', 25, 'New York', 'A');
console.log(person1.displayDetails());

// inheritance
console.log("inheritance")
class Student extends Person {
    constructor(name, age, city, grade, school) {
        super(name, age, city, grade);
        this.school = school;
    }
    displayDetails() {
        return `Name: ${this.name}, Age: ${this.age}, City: ${this.city}, Grade: ${this.grade}, School: ${this.school}`;
    }
}


const student1 = new Student('Mary', 22, 'Chicago', 'B', 'XYZ School');
console.log(student1.displayDetails());

class examdetails extends Student {
    constructor(name, age, city, grade, school, exam) {
        super(name, age, city, grade, school);
        this.exam = exam;
    }
    displayDetails() {
        return super.displayDetails() + `, Exam: ${this.exam}`;
    }
}

const exam1 = new examdetails('Tom', 20, 'Los Angeles', 'C', 'ABC School', 'Maths');

console.log(exam1.displayDetails());




//  prototype inheritance

console.log("prototype inheritance")
function PrototypePerson(first, last, age, eyecolor) {
    this.firstName = first;
    this.lastName = last;
    this.age = age;
    this.eyeColor = eyecolor;
}

PrototypePerson.prototype.name = function () {
    return this.firstName + " " + this.lastName;
};

const myFather = new PrototypePerson("John", "Doe", 50, "blue");

console.log(myFather.name());


