app.controller("AccountValidation", ["$scope", "$http", "$filter", function (s, r, f) {



    s.Sellers = [];
    s.Buyers = [];

    s.vSellers = [];
    s.vBuyers = [];

    s.tabSeller = 1;
    s.tabBuyer = 0;

    s.typeSeller = 0;
    s.typeBuyer = 0;

    s.isElementExistsAtDOMboolean = false;

    s.init = function () {

        r.get("../api/tUsers/getuseraccounts").then(function (d) {

            console.log(d.data)
            s.Sellers = d.data.sellers;
            s.Buyers = d.data.buyers;

        })

        r.get("../api/tUsers/GetUserVerifiedAccounts").then(function (d) {

            console.log(d.data)
            s.vSellers = d.data.sellers;
            s.vBuyers = d.data.buyers;

        })

    }





    s.cTab = function (usertype, val) {

        if (usertype == 1) {

            if (val == 0) {
                s.typeSeller = 0;
            }
            else {
                s.typeSeller = 1;
            }
        } else if (usertype == 2) {

            if (val == 0) {
                s.typeBuyer = 0;
            }
            else {
                s.typeBuyer = 1;
            }
        }
    }




    s.vUsersAccount = function (tab) {

        if (tab == 1) {

            s.tabSeller = 1;
            s.tabBuyer = 0;

        }

        else if (tab == 2) {

            s.tabSeller = 0;
            s.tabBuyer = 1;

        }
    }





    s.cActivateDeactivateAccount = function (type, index, action, userId) {

        console.log(type);
        // Deactivate
        if (action == 0) {

            console.log("Deactivate");

            swal({
                title: "Are you sure?",
                text: "This account will be deactivated!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, deactivate it!",
                closeOnConfirm: false
            }

            , function () {

                r.post("../api/tUsers/ActivateDeactivateAccount/" + action + "/" + userId).then(function (d) {

                    if (d.data != null) {

                        if (type == 1) {

                            s.vSellers[index].Status = d.data.Status;
                        } else if (type == 2) {

                            s.vBuyers[index].Status = d.data.Status;
                        }

                    }

                    else {

                    }
                 

                })

                swal("Deactivated!", "Account has been deactivated.", "success");
            });

 

        }

            // Activate
        else {




            swal({
                title: "Are you sure?",
                text: "This account will be activated!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, activate it!",
                closeOnConfirm: false
            }, function () {

                r.post("../api/tUsers/ActivateDeactivateAccount/" + action + "/" + userId).then(function (d) {

                
                    if (d.data != null) {

                        if (type == 1) {

                            s.vSellers[index].Status = d.data.Status;
                        } else if (type == 2) {

                            s.vBuyers[index].Status = d.data.Status;
                        }

             
                    }

                    else {

                    }
                })
                swal("Deactivated!", "Account has been activated.", "success");
            });
            console.log("Activate")
        }
    }





    s.isElementExistsAtDOM = function (id) {

     
        if (document.getElementById(id)) {

            s.isElementExistsAtDOMboolean = true;

        } else {

            s.isElementExistsAtDOMboolean = false;

        }
     
        return s.isElementExistsAtDOMboolean;
    }

    s.viewProfile = a => {
        location.href = "../Profile/user?uid="+ a +"";
    }

}]);