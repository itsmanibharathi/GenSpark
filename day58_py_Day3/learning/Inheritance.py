# python Inheritance 
#  create simple class

class Person:
    def __init__(self, fname, lname):
        self.firstname = fname
        self.lastname = lname
    def printname(self):
        print(self.firstname, self.lastname)

# create a child class
class Student(Person):
    def __init__(self, fname, lname, year):
        super().__init__(fname, lname)
        self.graduationyear = year
    def welcome(self):
        print(f'Welcome {self.firstname} {self.lastname} to the class of {self.graduationyear}')

x = Student('mani', 'm', 2024)
x.printname()

x.welcome()
