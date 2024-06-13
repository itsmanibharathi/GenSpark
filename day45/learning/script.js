
var prime = (num) => {
    for (let i = 2; i < num; i++) {
        if (num % i == 0) {
            return false;
        }
    }
    return true;
}

function primeFactors(num, Prime) {
    let factors = [];
    for (let i = 2; i <= num; i++) {
        if (num % i == 0 && Prime(i)) {
            factors.push(i);
        }
    }
    return factors;
}

console.log(primeFactors(100, prime));


function primeFactorsHOF(num, Prime) {
    let factors = [];
    for (let i = 2; i <= num; i++) {
        if (num % i == 0 && Prime(i)) {
            factors.push(i);
        }
    }
    return () => console.log(factors);
}

primeFactors = primeFactorsHOF(100, prime);
primeFactors();


// reduce 

let arr = [1, 2, 3, 4, 5];
let sum = arr.reduce((acc, curr) => acc + curr, 0);

console.log(sum);


// sort

let arrayOfNumbers=[22,45,99,3,8,44]
arrayOfNumbers.sort((numOne,numTwo)=>numOne-numTwo)
console.log(arrayOfNumbers)

