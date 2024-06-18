const loginbtn = () => {
  alert('Login button clicked');
  fetch('https://dummyjson.com/auth/login', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      username: document.getElementById('username').value,
      password: document.getElementById('password').value,
    })
  })
    .then(res => res.json())
    .then(console.log)
    .catch(err => console.log(err));
}