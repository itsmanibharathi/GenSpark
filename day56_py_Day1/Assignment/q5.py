# 5) Add validation the entered  name, age, date of birth and phone print details in proper format

while True:
    name = input("What is your name? ")
    if name.isalpha():
        break
    print("Please enter a valid name")

while True:
    age = input("How old are you? ")
    if age.isdigit():
        if int(age) > 0:
            break
    print("Please enter a valid age")

while True:
    dob = input("What is your date of birth? (dd/mm/yyyy) ")
    if dob:
        if dob.count("/") == 2:
            dob = dob.split("/")
            if len(dob[0]) == 2 and len(dob[1]) == 2 and len(dob[2]) == 4:
                break
    print("Please enter a valid date of birth (dd/mm/yyyy)")

while True:
    phone = input("What is your phone number? ")
    if phone.isdigit():
        if len(phone) == 10:
            break
    print("Please enter a valid phone number")

print(f"Name: {name}, Age: {age}, DOB: {dob}, Phone: {phone}")
