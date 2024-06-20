
document.getElementById('form').addEventListener('submit', (e) => {
    e.preventDefault();
    const data = [
        {
            email: 'mani@gmail.com',
            password: '1234'
        },
    ]
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const msg = document.getElementById('message');
    if (email === '' || password === '') {
        msg.innerHTML = 'All fields are required';
        msg.style.color = 'red';
    } else if (data.some((item) => item.email === email && item.password === password)) {
        msg.innerHTML = 'login successful';
        msg.style.color = 'green';
    }
    else {
        msg.innerHTML = 'Invalid email or password';
        msg.style.color = 'red';
    }
});