let imageCrop = $("#imageCrop");
let cropper = '';


function browseFile(file) {
    
    var input = file.target;
    //set flag for browse file or capture image
    localStorage.setItem("flag", "browse");

    var reader = new FileReader();
    reader.onload = function (e) {
        var dataURL = reader.result;
        var output = document.getElementById('browseOutput');
        if(e.target.result){
            // create new image
            let img = document.createElement('img');
            img.id = 'image';
            img.src = e.target.result;
            $("#browse").val(null)
            $("#imageCrop").empty();
            $("#imageCrop").append(img);
            $("#cropperModal").modal({show: true});
            
            // init cropper
            $("#image").cropper({
                aspectRatio: 1
            });
        }
    };
    reader.readAsDataURL(input.files[0]);   
};
 


//Capturing Image
function captureImage() {
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
    setInterval(function() {
        var loadingDot = $("#loadingDot");
        loadingDot.append(".");

        if(loadingDot.text().length > 3) {
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
    $("#snap").click(function() {
        var context = document.getElementById("canvas").getContext('2d');
        var canvas = document.getElementById("canvas");
        context.drawImage(document.getElementById('video'), 0, 0, 640, 480);
        let img = document.createElement('img');
        img.id = 'image';
        img.src = canvas.toDataURL('image/png');
        $("#imageCrop").empty();
        $("#imageCrop").append(img);
        setTimeout(function() {
            $("#modal_default").modal('show');
        }, 500);

        $("#image").cropper({
            aspectRatio: 1
        });
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
    if(flag === "browse") {
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
