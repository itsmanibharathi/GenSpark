# 3) Take name and gender print greet with salutation


name = input("Enter your name: ")
gender = input("Enter your gender (M/F): ")

if gender.lower() == 'm':
    print(f"Hello Mr. {name}")

elif gender.lower() == 'f':
    print(f"Hello Ms. {name}")

else:
    print("invalid gender")