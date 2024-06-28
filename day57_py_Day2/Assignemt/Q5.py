# 5) Credit card validation - Luhn check algorithm

def luhn_check(card_number):
    if len(card_number)>16:
        return False
    card_number.reverse()
    sum = 0
    for i, num in enumerate(card_number):
        if i % 2 != 0:
            num *= 2
            if num > 9:
                num -= 9
        sum += num
    return sum % 10 == 0

card_number = input("Enter card number: ")
card_number = [int(num) for num in card_number]
print("the card number is valid: ", luhn_check(card_number))