app.controller("RegisterCtrl", ["$scope", "$http", function (s, h) {

    s.cropImg = $('#cropImg').croppie({
        enableExif: true,
        mouseWheelZoom: false,
        viewport: {
            width: 300,
            height: 300,
            type: 'square'
        },
        boundary: {
            width: 350,
            height: 350
        }
    });

    $('#front-picture').on('change', function () {
        //crop flag 0 front
        s.cropFlag = 0;
        var reader = new FileReader();
        reader.onload = function (event) {
            s.cropImg.croppie('bind', {
                url: event.target.result
            }).then(function () {
                console.log('jQuery bind complete');
            });
        }
        reader.readAsDataURL(this.files[0]);

        //$("#newProduct").modal("hide");
        $("#uploadImg").modal("show");
        s.uploadImgID = true;
    });

    $('#back-picture').on('change', function () {
        //crop flag 1 back
        s.cropFlag = 1;
        var reader = new FileReader();
        reader.onload = function (event) {
            s.cropImg.croppie('bind', {
                url: event.target.result
            }).then(function () {
                console.log('jQuery bind complete');
            });
        }
        reader.readAsDataURL(this.files[0]);

        //$("#newProduct").modal("hide");
        $("#uploadImg").modal("show");
        s.uploadImgID = true;
    });

    s.uploadImg = function () {
        s.cropImg.croppie('result', {
            type: 'canvas',
            size: 'viewport'
        }).then(function (response) {
            if (s.cropFlag) {
                s.register.frontImage = response.split(',')[1];
            } else {
                s.register.backImage = response.split(',')[1];
            }
            //console.log(s.register)
            $("#uploadImg").modal("hide");
        })

    }


    s.finish = function () {
        h.post("../api/Registration", s.register).then(function (d) {
            let user = {
                UserId: d.data
            }
            //location.href = "../Home/Index";
            h.post("../Account/auth", user).then(function () {
                location.href = "../Home/Index";
            });
        });
    }

}]);