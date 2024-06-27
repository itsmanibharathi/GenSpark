// function employeeDetails(employeeName,employeeSalary){
//     this.employeeName=employeeName
//     this.employeeSalary=employeeSalary
//     this.displayDetails=()=>{
//         return "Employee name is "+this.employeeName+" and salary is "+this.employeeSalary
//     }
// }
// const firstEmployee= new employeeDetails('John',20000)
// const secondEmployee= new employeeDetails('Mary',30000)

// // console.log(firstEmployee.displayDetails())
// // console.log(secondEmployee.displayDetails())
// console.log(firstEmployee.employeeName)
// console.log(secondEmployee.employeeName)


class Vehicle
{
    constructor(vehicleType,modelName)
    {
        this.vehicleType=vehicleType
        this.modelName=modelName
    }
    displayDetails()
    {
        console.log(`The type of Vehicle is ${this.vehicleType} and the model is ${this.modelName}`)
    }
}
// let vehicleOne=new Vehicle('Car','Audi')
// vehicleOne.displayDetails()

console.log("inheritance and polymorphism")

// inheritance

class Car extends Vehicle
{
    constructor(vehicleType,modelName,carColor)
    {
        super(vehicleType,modelName)
        this.carColor=carColor
    }
    displayDetails()
    {
        console.log(`The type of Vehicle is ${this.vehicleType} and the model is ${this.modelName} and the color is ${this.carColor}`)
    }
}   

let carOne=new Car('Car','Audi','Red')

carOne.displayDetails()




console.log("Polymorphism")

//Polymorphism

class Animal
{
    walking()
    {
        console.log("Animal is walking")
    }

}

class Tiger extends Animal
{
    walking()
    {
        console.log("Tiger is walking with four legs")
    }

}

class Bear extends Animal
{
    walking()
    {
        console.log("Bear is walking with two legs")
    }

}

const animals=[new Tiger(),new Bear()]
animals.forEach(animal=>animal.walking())

class Shape
{
    area(valueOne,valueTwo)
    {
        console.log(valueOne*valueTwo)
    }
}



class Rectangle extends Shape
{
    area(valueOne,valueTwo)
    {
        super.area(valueOne,valueTwo)
    }
}

let rectangle=new Rectangle()
rectangle.area(6,8)

class Person
{
    startWalking()
    {
        console.log("Person starts walking from his home")
    }
    reachedGroceryShop()
    {
        this.startWalking()
        console.log("Reached the grocery shop")
    }
}

let ram=new Person()
ram.reachedGroceryShop()


