import datetime
import csv
import os
from fpdf import FPDF
import pandas as pd

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


def save_to_text(person, path):
    with open(f'{path}/person_{person.name}.txt', 'w') as f:
        f.write(str(person))


def save_to_csv(person, path):
    with open(f'{path}/person_{person.name}.csv', 'w', newline='') as f:
        writer = csv.writer(f)
        writer.writerow(['Name', 'Age', 'Phone', 'Email'])
        writer.writerow([person.name, person.age, person.phone, person.email])


def save_to_pdf(person, path):
    class PDF(FPDF):
        def header(self):
            self.set_font('Arial', 'B', 12)
            self.cell(0, 10, 'Person Details', 0, 1, 'C')

        def footer(self):
            self.set_y(-15)
            self.set_font('Arial', 'I', 8)
            self.cell(0, 10, f'Page {self.page_no()}', 0, 0, 'C')

    pdf = PDF()
    pdf.add_page()
    pdf.set_font('Arial', 'B', 12)
    pdf.cell(0, 10, f'Name: {person.name}', 0, 1)
    pdf.cell(0, 10, f'Age: {person.age}', 0, 1)
    pdf.cell(0, 10, f'Phone: {person.phone}', 0, 1)
    pdf.cell(0, 10, f'Email: {person.email}', 0, 1)
    pdf.output(f'{path}/person_{person.name}.pdf')


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
    basepath = 'day58_py_Day3/Assignment/Datas'
    os.makedirs(basepath, exist_ok=True)
    store_format = input('Store in which format? (text, csv, pdf): ')
    if store_format == 'text':
        save_to_text(data, basepath)
    elif store_format == 'csv':
        save_to_csv(data, basepath)
    elif store_format == 'pdf':
        save_to_pdf(data, basepath)
    else:
        print('Invalid format')

if __name__ == '__main__':
    main()
