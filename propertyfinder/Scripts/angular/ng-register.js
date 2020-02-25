app.controller("RegisterCtrl", ["$scope", "$http", function (s, h) {

    //s.cropImg = $('#cropImg').croppie({
    //    enableExif: true,
    //    mouseWheelZoom: false,
    //    viewport: {
    //        width: 300,
    //        height: 300,
    //        type: 'square'
    //    },
    //    boundary: {
    //        width: 350,
    //        height: 350
    //    }
    //});


   

    //$('#front-picture').on('change', function () {
    //    //crop flag 0 front
    //    s.cropFlag = 0;
    //    var reader = new FileReader();
    //    reader.onload = function (event) {
    //        s.cropImg.croppie('bind', {
    //            url: event.target.result
    //        }).then(function () {
    //            console.log('jQuery bind complete');
    //        });
    //    }
    //    reader.readAsDataURL(this.files[0]);

    //    //$("#newProduct").modal("hide");
    //    $("#uploadImg").modal("show");
    //    s.uploadImgID = true;
    //});

    //$('#back-picture').on('change', function () {
    //    //crop flag 1 back
    //    s.cropFlag = 1;
    //    var reader = new FileReader();
    //    reader.onload = function (event) {
    //        s.cropImg.croppie('bind', {
    //            url: event.target.result
    //        }).then(function () {
    //            console.log('jQuery bind complete');
    //        });
    //    }
    //    reader.readAsDataURL(this.files[0]);

    //    //$("#newProduct").modal("hide");
    //    $("#uploadImg").modal("show");
    //    s.uploadImgID = true;
    //});

    //s.uploadImg = function () {
    //    s.cropImg.croppie('result', {
    //        type: 'canvas',
    //        size: 'viewport'
    //    }).then(function (response) {
    //        if (s.cropFlag) {
    //            s.register.frontImage = response.split(',')[1];
    //        } else {
    //            s.register.backImage = response.split(',')[1];
    //        }
    //        //console.log(s.register)
    //        $("#uploadImg").modal("hide");
    //    })

    //}


    s.finish = function () {
        s.register.frontImage = $("#frontPreview").attr("src");
        s.register.backImage = $("#backPreview").attr("src");
        s.register.profilepic = $("#profilepic").attr("src");


        var con = confirm("Are you sure?");
        if (con) {
            h.post("../api/Registration", s.register).then(function (d) {
                let user = {
                    UserId: d.data
                }
                //location.href = "../Home/Index";
                s.auth(user);
            });
            console.log(s.register)
        } else {
            return false;
        }
    }

    s.auth = function (u) {
        h.post("../Account/auth", u).then(function (d) {
            location.href = "../Home/Index";
        });
    }

}]);

function browseFile(file) {

    var input = file.target;
    //set flag for browse file or capture image
    localStorage.setItem("flag", "browse");

    var reader = new FileReader();
    reader.onload = function (e) {
        if (e.target.result) {
            // create new image
            $("#frontPreview").attr("src", e.target.result);
            $("#front-picture").val(null);
        }
    };
    reader.readAsDataURL(input.files[0]);
};

//profile picture browse
function browseProfile(file) {
    var input = file.target;

    var reader = new FileReader();
    reader.onload = function (e) {
        if (e.target.result) {
            // create new image
            $("#profilepic").attr("src", e.target.result);
            $("#profile-picture").val(null)

        }
    };
    reader.readAsDataURL(input.files[0]);
}

function browseFile2(file) {

    var input = file.target;

    var reader = new FileReader();
    reader.onload = function (e) {
        if (e.target.result) {
            // create new image
            $("#backPreview").attr("src", e.target.result);
            $("#back-picture").val(null)

        }
    };
    reader.readAsDataURL(input.files[0]);
};

function captureImage(type) {
    $("#cameraModal").modal("show");


    var video = document.getElementById('video'),
        errorMsgElement = $('span#errorMsg');
    video.play();
    video.style.display = "";
    //set the flag 0 for capture image
    localStorage.setItem("flag", "capture");
    $("#hovtosee").hide()
    $(".video-wrap").show();

    $("#img-icon").hide(); //hide image icon capture
    $("#captureImageText").hide();//hide capture image text

    //loading animation while waiting for the webcam
    $("#loadingDot").text("");
    $(".video-wrap").append("<div style='font-size: 20px;' id='loadingOnVW'>Please wait! This may take a while<span id='loadingDot'></span></div>");
    setInterval(function () {
        var loadingDot = $("#loadingDot");
        loadingDot.append(".");

        if (loadingDot.text().length > 3) {
            $("#loadingDot").text(null);
        }
    }, 500);
    //constraints for user media
    const constraints = {
        audio: false,
        video: {
            width: 1280, height: 720
        }
    };
    // Access webcam
    async function init() {
        try {
            const stream = await navigator.mediaDevices.getUserMedia(constraints);
            handleSuccess(stream);
        } catch (e) {
            //errorMsgElement.text(`navigator.getUserMedia error:${e.toString()}`);
        }
    }
    // Success
    function handleSuccess(a) {
        $("#loadingOnVW").remove();
        $("#snap").show();
        window.stream = a;
        video.srcObject = window.stream;
    }
    // Load init
    init();
    // Draw image
    //var context = canvas.getContext('2d');
    $("#snap").click(function () {
        var context = document.getElementById("canvas").getContext('2d');
        var canvas = document.getElementById("canvas");
        context.drawImage(document.getElementById('video'), 0, 0, 640, 480);


        if (type == 1) {
            $("#profilepic").attr("src", canvas.toDataURL('image/png'));
        } else if (type == 2) {
            $("#frontPreview").attr("src", canvas.toDataURL('image/png'));
        } else {
            $("#backPreview").attr("src", canvas.toDataURL('image/png'));
        }
        
    });
}





function saveChanges() {
    var flag = localStorage.getItem("flag");
    var video = document.getElementById('video');
    var resultImgCropped = $("#image").cropper("getCroppedCanvas", {
        width: 300,
        height: 300,
        imageSmoothingQuality: "high"
    }).toDataURL("image/png");
    $("#modal_default").modal('hide');
    $("#hovtosee").show();
    document.getElementById("hovtosee").style.display = "block";
    document.getElementById("img-icon").style.display = "block";
    $("#captureImageText").show();
    if (flag === "browse") {
        //browse file
        $("#img-icon").attr("src", resultImgCropped);
        video.pause();
        video.currentTime = 0;
        video.style.display = "none";
    } else {
        //capture image
        $("#img-icon").attr("src", resultImgCropped);
        snap.style.display = "none";
        video.pause();
        video.currentTime = 0;
        video.style.display = "none";
    }
}
