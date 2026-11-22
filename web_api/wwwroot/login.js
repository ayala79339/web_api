// JavaScript source code
const logupbut = document.getElementById("logup_but")
const loginbut = document.getElementById("login_but")
const updatebut = document.getElementById("update_but")
const left = document.getElementById("left")
const update = document.getElementById("update")
const text = document.getElementById("text")
//In JavaScript, names are camelCase: passStrengh (the id in update.html stays pass_strengh)
const pass_strengh = document.getElementById("pass_strengh")

const curr_user = JSON.parse(localStorage.getItem('current user'));
if (text)
    text.innerHTML = `hello and wellcome ${curr_user.firstName} ${curr_user.lastName}`

const show_logup =() => {
    left.style.display='block'
}
const show_update = () => {
    update.style.display = 'block'
}
 
const log_up = async () => {
  try {
    const DataToPost = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("first_name").value,
        lastName: document.getElementById("last_name").value

    }

    const response = await fetch('/users/loguppost',
        { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(DataToPost) })
    if (response.ok)
    {
        throw ("המשתמש נרשם בהצלחה!")
       
    }
    else
        throw (`יש בעיה!-קוד שגיאה: ${response.status}`)
}
    catch (e) {
        alert(e)
    }
}

const log_in = async () => {
  
    const LogDataToPost = {
        email: document.getElementById("logemail").value,
        password: document.getElementById("logpassword").value
    }
    const response = await fetch('/users/loginpost',
        { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(LogDataToPost) })

    if (response.status==200) {
        const response_data = await response.json()
        localStorage.setItem('current user', JSON.stringify(response_data))
        
        window.location.href = "update.html";       
    }
    else
        alert(response.status)
 
   
  }
   
async function update_user() {

    const dataToUpdate = {
        email: document.getElementById("updateEmail").value,
        password: document.getElementById("updatePassword").value,
        firstName: document.getElementById("updateFirstName").value,
        lastName: document.getElementById("updateLastName").value
    }   

    const id = curr_user.id

    //Is the id from curr_user used in this URL? The URL should contain the id, and the route of PUT must match it
    const response = await fetch('users/id',
        { method: 'PUT', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(dataToUpdate) }
    )
    if (response.ok)
        alert("הפרטים עודכנו בהצלחה!")

    else
        alert("משהו השתבש בדרך-נסה שנית!")

}
 

async function check_pass()
{
    
    const response = await fetch('password/check_strengh', { method: 'post', headers: { 'content-Type': 'application/json' }, body: JSON.stringify(curr_user.password) })
    if (response.ok) {
        //Where is score declared? It is used here without a declaration
        score = await response.json();
        
        pass_strengh.innerHTML = `password strengh: ${score}`;
    }
    else
        pass_strengh.innerHTML = `can not check password strengh! try again`;

}