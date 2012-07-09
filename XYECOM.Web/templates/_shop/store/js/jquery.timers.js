(function() {
    var a = Date.parse;
    Date.parse = function(b) {
        var d = a(b),
        c = 0,
        e;
        if (isNaN(d) && (e = /(\d{4})-?(\d{2})-?(\d{2})(?:[T ](\d{2}):?(\d{2}):?(\d{2})(?:\.(\d{3,}))?(?:(Z)|([+\-])(\d{2})(?::?(\d{2}))?)?)/.exec(b))) {
            if (e[7] == undefined) {
                e[7] = "000"
            }
            if (e[8] != undefined && e[8] !== "Z") {
                c = +e[10] * 60 + ( + e[11]);
                if (e[9] === "+") {
                    c = 0 - c
                }
            }
            d = Date.UTC( + e[1], +e[2] - 1, +e[3], +e[4], +e[5] + c, +e[6], +e[7].substr(0, 3))
        }
        return d
    }
} ()); (function(a) {
    a.fn.extend({
        timer: function(b) {
            var f, j, h = new Date(),
            e = 1000;
            var g = h.getTime(),
            i = Date.parse(b);
            f = parseInt(i - g) / 1000;
            var c = a(this);
            j = window.setInterval(function() {
                if (f > 1) {
                    f = f - 1;
                    var k = Math.floor(f % 60);
                    var l = Math.floor((f / 60) % 60);
                    var d = Math.floor((f / 3600) % 24);
                    var m = Math.floor((f / 3600) / 24);
                    if (m > 1) {
                        c.html("剩余<b>" + m + "</b>天");
                        window.clearInterval(j)
                    } else {
                        c.html("剩余时间<b>" + d + "</b>小时<b>" + l + "</b>分<b>" + k + "</b>秒")
                    }
                } else {
                    window.clearInterval(j)
                }
            },
            e)
        }
    })
})(jQuery);