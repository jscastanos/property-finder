app.controller("SignUp", ["$scope", "$http", "$filter", function (s, r, f) {



    s.user = {};
    s.cpassword = "";
    s.valid = false;

    s.chkBox;
    s.validUsername = null;



    s.btnSeller = 1;
    s.btnBuyer = 1;






    s.init = function () {


        s.user.AccountTypeId = 0;
    }





    s.cBox = function (val) {

        console.log(val)
        s.chkBox = val;
    }



    s.validation = function () {

        if (s.cpassword != null) {

            if (s.user.Password != s.cpassword) {
                s.valid = true;
            }
            else if (s.user.Password == s.cpassword) {
                s.valid = false;
            }
        }

        else {

            s.valid = true;
        }



    }




    // Create Users account
    s.createAccount = function () {
        r.post("../api/tUsers/createaccount", s.user).then(function (d) {

            if (d.data != null) {
                s.user = {};
                s.cpassword = null;
                s.chkBox = false;
                location.href = "../Account/Register";
            }
        });

    }


    // Create Users account
    s.ValidateUsername = function () {


        r.post("../api/tUsers/validateusername/" + s.user.Username).then(function (d) {

            console.log(d.data)
            s.validUsername = d.data;

        })

    }




    s.selectAccountType = function (type, click) {


       
        if (type == 1) {

            s.btnSeller = 0;
            s.btnBuyer = 1;

            s.user.AccountTypeId = type;
            console.log(s.user.AccountTypeId)
        }

        else {

            s.btnSeller = 1;
            s.btnBuyer = 0;

            s.user.AccountTypeId = type;
            console.log(s.user.AccountTypeId)
        }

        
    }













    s.gotToLogInPage = function () {
        location.href = "../account/login";
    }
}]);