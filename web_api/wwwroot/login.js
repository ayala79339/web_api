// JavaScript source code
const logupbut = document.getElementById("logup_but")
const loginbut = document.getElementById("login_but")
const updatebut = document.getElementById("update_but")
const left = document.getElementById("left")
const update = document.getElementById("update")
const text = document.getElementById("text")



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
        first_name: document.getElementById("first_name").value,
        last_name: document.getElementById("last_name").value

    }

    const response = await fetch('/users/loguppost',
        { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(DataToPost) })
    if (response.ok)
        throw ("המשתמש נרשם בהצלחה!")
    else
        throw (`יש בעיה!-קוד שגיאה: ${response.status}`)
}
    catch (e) {
        alert(e.message)
    }
}

const log_in = async () => {
  
    const LogDataToPost = {
        email: document.getElementById("logemail").value,
        password: document.getElementById("logpassword").value
    }
    const response = await fetch('/users/loginpost',
        { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(LogDataToPost) })

    if (response.ok) {
        const response_data = await response.json()
        localStorage.setItem('current user' ,JSON.stringify(response_data))
        window.location.href = "update.html";
       
    }
    else
        alert(response.status)
 
   
  }
   
async function update_user() {
    
      const dataToUpdate = {
                email: document.getElementById("updateEmail").value,
                password: document.getElementById("updatePassword").value,
                first_name: document.getElementById("updateFirstName").value,
                last_name: document.getElementById("updateLastName").value
    }    
    const curr_user = JSON.parse(localStorage.getItem('current user'));

    const id=curr_user.id
     
           const response = await fetch('users/id',
                { method: 'PUT', headers: { 'Content-Type': 'application/json' },body:JSON.stringify(dataToUpdate) }
           )
            if (response.ok)
              alert("הפרטים עודכנו בהצלחה!")

            else
               alert ("משהו השתבש בדרך-נסה שנית!")
        
       
    }
    

