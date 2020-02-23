app.controller("LogIn", ["$scope", "$http", "$filter", function (s, r, f) {



    s.user = {};
    s.result = null;








    s.init = function () {

    }


    s.LogIn = function () {



        r.post("../Account/auth", s.user).then(function (d) {
            if (d.data != null) {
                console.log(d.data)
                s.user = {};
                s.result = d.data;
            }
            else {
                s.result = 3;
                console.log(d.data)
            }
        })
    }


    s.gotToSignUpPage = function () {
        location.href = "../account/signup";
    }
}]);