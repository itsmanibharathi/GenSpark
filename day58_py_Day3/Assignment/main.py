import datetime

class Person:
    def __new__(cls, *args, **kwargs):
        return super(Person, cls).__new__(cls)
    
    def __init__(self, name=None, dob=None, phone=None, email=None):
        self.name = name
        self.dob = dob
        self.phone = phone
        self.email = email
        self.age = self.calculate_age() if dob else None
    
    def calculate_age(self):
        dob = datetime.datetime.strptime(self.dob, '%d-%m-%Y')
        today = datetime.datetime.today()
        age = today.year - dob.year
        if today.month < dob.month or (today.month == dob.month and today.day < dob.day):
            age -= 1
        return age
    
    def __str__(self) -> str:
        return f'{self.name} is {self.age} years old. Phone: {self.phone}, Email: {self.email}'
    
    def __repr__(self) -> str:
        return f'{{"name": "{self.name}", "age": {self.age}, "phone": "{self.phone}", "email": "{self.email}"}}'

# person = Person.__new__(Person)

# # Manually set the attributes
# person.name = "John Doe"
# person.dob = "10-10-1990"
# person.phone = "123-456-7890"
# person.email = "johndoe@example.com"
# person.age = person.calculate_age()

# # Now you can use the person object
# print(person)
# print(repr(person))


def main():
    print('Create new person object')
    data = Person.__new__(Person)
    print('Enter the following details')
    while True:
        data.name = input('Name: ')
        if data.name:
            break
        else:
            print('Name is required')
    while True:
        data.dob = input('Date of Birth (dd-mm-yyyy): ')
        if data.dob:
            if not data.dob.count('-') == 2:
                print('Invalid Date of Birth format')
                continue
            break
        else:
            print('Date of Birth is required')
    while True:
        data.phone = input('Phone: ')
        if data.phone:
            if not data.phone.isdigit():
                print('Invalid Phone number')
                continue
            elif not len(data.phone) == 10:
                print('Phone number must be 10 digits')
                continue
            break
        else:
            print('Phone is required')
    while True:
        data.email = input('Email: ')
        if data.email:
            if not '@' in data.email or not '.' in data.email:
                print('Invalid Email')
                continue
            break
        else:
            print('Email is required')
    data.age = data.calculate_age()
    basepath = f'day58_py_Day3/Assignment/Datas/'
    store_format = input('Store in which format? (text, xl, pdf): ')
    if store_format == 'text':
        with open(f'{basepath}/txt/person{data.name}.txt', 'w') as f:
            f.write(str(data))
    elif store_format == 'xl':
        with open(f'{basepath}/csv/person{data.name}.csv', 'w') as f:
            f.write(f'{data.name},{data.age},{data.phone},{data.email}')
    elif store_format == 'pdf':
        with open(f'{basepath}/pdf/person{data.name}.pdf', 'w') as f:
            f.write(repr(data))
    else:
        print('Invalid format')
main()
