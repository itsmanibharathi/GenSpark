



# 7) Take 10 numbers and find the average of all the prime numbers in the collection

prime_numbers = []
for i in range(10):
    num = int(input("Enter a number: "))
    if num > 1:
        for i in range(2, num):
            if num % i == 0:
                break
        else:
            prime_numbers.append(num)

print("Average of prime numbers:", sum(prime_numbers) / len(prime_numbers))
print("Prime numbers are:", prime_numbers)