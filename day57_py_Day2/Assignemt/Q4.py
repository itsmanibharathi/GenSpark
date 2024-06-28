# 4) Application to play the Cow and Bull game maintain score as well.
#  - reff - Wordle of New York Times

def calculate_cow_bull(secret, guess):
    cow = 0
    bull = 0
    for i in range(len(secret)):
        if secret[i] == guess[i]:
            cow += 1
        elif guess[i] in secret:
            bull += 1
    return cow, bull

def cow_bull_game():
    secret = "mani"
    score = 4
    chances = 0
    while chances < 5:
        while True:
            guess = input("Enter your guess: ")
            if guess.isalpha() and len(guess) == 4:
                break
            else:
                print("Enter a valid guess it should be a 4 letter word")
        chances += 1
        if guess == secret:
            print("You have guessed the correct word")
            break
        else:
            cow, bull = calculate_cow_bull(secret, guess)
            score -= 1
            print("Cow: {} Bull: {}".format(cow, bull))

    print("Your score is: ", score)


cow_bull_game()





