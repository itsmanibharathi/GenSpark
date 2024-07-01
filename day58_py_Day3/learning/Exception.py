#  Exception Handling python
#  try, except, else, finally

def divide(x, y):
    try:
        result = x / y
    except ZeroDivisionError:
        print('division by zero!')
    except Exception as e:
        print('Exception is', e)
    else: # else block is executed if the try block does not raise an exception
        print('result is', result)
    finally:
        print('executing finally clause')

divide(2, 1)

divide(2, 0)

divide('2', '1')
