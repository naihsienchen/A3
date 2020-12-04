window.onload = function(){

    var formHandle = document.forms.NewTeacher;
    var TeacherFname = document.getElementById("TeacherFname").value;
    console.log(formHandle);
    
    formHandle.onsubmit = processForm;

    function processForm(){
        
        //////* form validation javascript doesn't work yet. need more testing. *//////

        /*
        if (TeacherFname === "") {
            alert('no value inserted');
            return false;
        }
        else {
            console.log(TeacherFname);//IT'S THE VALUE WE NEED TO ACCESS THE INPUT FROM THE TEXT BOX
            alert('else: form sent');
        }
        */
    }
  
}//onload ends