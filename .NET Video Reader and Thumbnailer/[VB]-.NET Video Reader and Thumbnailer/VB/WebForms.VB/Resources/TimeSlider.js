
function createTimeSlider(timeSliderId, videoFrameId, totalSeconds) {
    var slider = document.getElementById(timeSliderId);

    noUiSlider.create(slider, {
        start: 0,
        range: {
            "min": 0,
            "max": totalSeconds
        },
        step: 1,
        pips: {
            mode: 'range',
            density: 60,
            format: { to: formatDuration }
        },
        tooltips: { to: formatDuration }
    });

    var videoFrame = document.getElementById(videoFrameId);

    slider.noUiSlider.on('change', function() {
        var src = videoFrame.src;
        var time = Math.floor(+slider.noUiSlider.get());
        videoFrame.src = src.substr(0, src.lastIndexOf("=") + 1) + time;
    });
}

function formatDuration(seconds) {
    var h1 = Math.floor(seconds / (60 * 60));
    seconds %= 60 * 60;
    var m1 = Math.floor(seconds / 60);
    seconds = Math.floor(seconds % 60);
    var h2 = h1 ? h1 + ':' : '',
        m2 = h1 && m1 < 10 ? '0' + m1 : m1,
        s2 = seconds < 10 ? '0' + seconds : seconds;
    return h2 + m2 + ':' + s2;
}