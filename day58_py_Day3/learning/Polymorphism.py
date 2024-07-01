# Polymorphism with constructor animal example

class Animal:
    available_name =[];
    def __init__(self, name):
        self.available_name.append(name)
        self.name = name

    def speak(self):
        raise NotImplementedError("Subclass must implement this abstract method")
    
    def __str__(self):
        for name in self.available_name:
            return name
    
class Dog(Animal):
    def __init__(self, name):
        super().__init__(name)
    
    def speak(self):
        return f'{self.name} says woof!'
    
class Cat(Animal):

    def __init__(self, name):
        super().__init__(name)
    
    def speak(self):
        return f'{self.name} says meow!'
    

    
fido = Dog('Fido')
isis = Cat('Isis')

print(fido.speak())
print(isis.speak())


