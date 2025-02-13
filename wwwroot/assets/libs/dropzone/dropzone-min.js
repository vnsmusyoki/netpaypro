!(function () {
    function e(e) {
        return e && e.__esModule ? e.default : e;
    }
    function t(e) {
        if (void 0 === e)
            throw new ReferenceError(
                "this hasn't been initialised - super() hasn't been called"
            );
        return e;
    }
    function i(e, t) {
        if (!(e instanceof t))
            throw new TypeError("Cannot call a class as a function");
    }
    function n(e, t) {
        for (var i = 0; i < t.length; i++) {
            var n = t[i];
            (n.enumerable = n.enumerable || !1),
                (n.configurable = !0),
                "value" in n && (n.writable = !0),
                Object.defineProperty(e, n.key, n);
        }
    }
    function r(e, t, i) {
        return t && n(e.prototype, t), i && n(e, i), e;
    }
    function a(e) {
        return (
            (a = Object.setPrototypeOf
                ? Object.getPrototypeOf
                : function (e) {
                    return e.__proto__ || Object.getPrototypeOf(e);
                }),
            a(e)
        );
    }
    function o(e, t) {
        return (
            (o =
                Object.setPrototypeOf ||
                function (e, t) {
                    return (e.__proto__ = t), e;
                }),
            o(e, t)
        );
    }
    function l(e, t) {
        if ("function" != typeof t && null !== t)
            throw new TypeError("Super expression must either be null or a function");
        (e.prototype = Object.create(t && t.prototype, {
            constructor: { value: e, writable: !0, configurable: !0 },
        })),
            t && o(e, t);
    }
    function s(e, i) {
        return !i ||
            ("object" !=
                ((n = i) && n.constructor === Symbol ? "symbol" : typeof n) &&
                "function" != typeof i)
            ? t(e)
            : i;
        var n;
    }
    var u;
    function c(e) {
        return Array.isArray(e) || "[object Object]" == {}.toString.call(e);
    }
    function d(e) {
        return !e || ("object" != typeof e && "function" != typeof e);
    }
    u = function e() {
        var t = [].slice.call(arguments),
            i = !1;
        "boolean" == typeof t[0] && (i = t.shift());
        var n = t[0];
        if (d(n)) throw new Error("extendee must be an object");
        for (var r = t.slice(1), a = r.length, o = 0; o < a; o++) {
            var l = r[o];
            for (var s in l)
                if (Object.prototype.hasOwnProperty.call(l, s)) {
                    var u = l[s];
                    if (i && c(u)) {
                        var h = Array.isArray(u) ? [] : {};
                        n[s] = e(
                            !0,
                            Object.prototype.hasOwnProperty.call(n, s) && !d(n[s]) ? n[s] : h,
                            u
                        );
                    } else n[s] = u;
                }
        }
        return n;
    };
    var h = (function () {
        "use strict";
        function e() {
            i(this, e);
        }
        return (
            r(e, [
                {
                    key: "on",
                    value: function (e, t) {
                        return (
                            (this._callbacks = this._callbacks || {}),
                            this._callbacks[e] || (this._callbacks[e] = []),
                            this._callbacks[e].push(t),
                            this
                        );
                    },
                },
                {
                    key: "emit",
                    value: function (e) {
                        for (
                            var t = arguments.length, i = new Array(t > 1 ? t - 1 : 0), n = 1;
                            n < t;
                            n++
                        )
                            i[n - 1] = arguments[n];
                        this._callbacks = this._callbacks || {};
                        var r = this._callbacks[e],
                            a = !0,
                            o = !1,
                            l = void 0;
                        if (r)
                            try {
                                for (
                                    var s, u = r[Symbol.iterator]();
                                    !(a = (s = u.next()).done);
                                    a = !0
                                ) {
                                    var c = s.value;
                                    c.apply(this, i);
                                }
                            } catch (e) {
                                (o = !0), (l = e);
                            } finally {
                                try {
                                    a || null == u.return || u.return();
                                } finally {
                                    if (o) throw l;
                                }
                            }
                        return (
                            this.element &&
                            this.element.dispatchEvent(
                                this.makeEvent("dropzone:" + e, { args: i })
                            ),
                            this
                        );
                    },
                },
                {
                    key: "makeEvent",
                    value: function (e, t) {
                        var i = { bubbles: !0, cancelable: !0, detail: t };
                        if ("function" == typeof window.CustomEvent)
                            return new CustomEvent(e, i);
                        var n = document.createEvent("CustomEvent");
                        return n.initCustomEvent(e, i.bubbles, i.cancelable, i.detail), n;
                    },
                },
                {
                    key: "off",
                    value: function (e, t) {
                        if (!this._callbacks || 0 === arguments.length)
                            return (this._callbacks = {}), this;
                        var i = this._callbacks[e];
                        if (!i) return this;
                        if (1 === arguments.length) return delete this._callbacks[e], this;
                        for (var n = 0; n < i.length; n++) {
                            var r = i[n];
                            if (r === t) {
                                i.splice(n, 1);
                                break;
                            }
                        }
                        return this;
                    },
                },
            ]),
            e
        );
    })();
    var p = {
        url: null,
        method: "post",
        withCredentials: !1,
        timeout: null,
        parallelUploads: 2,
        uploadMultiple: !1,
        chunking: !1,
        forceChunking: !1,
        chunkSize: 2097152,
        parallelChunkUploads: !1,
        retryChunks: !1,
        retryChunksLimit: 3,
        maxFilesize: 256,
        paramName: "file",
        createImageThumbnails: !0,
        maxThumbnailFilesize: 10,
        thumbnailWidth: 120,
        thumbnailHeight: 120,
        thumbnailMethod: "crop",
        resizeWidth: null,
        resizeHeight: null,
        resizeMimeType: null,
        resizeQuality: 0.8,
        resizeMethod: "contain",
        filesizeBase: 1e3,
        maxFiles: null,
        headers: null,
        defaultHeaders: !0,
        clickable: !0,
        ignoreHiddenFiles: !0,
        acceptedFiles: null,
        acceptedMimeTypes: null,
        autoProcessQueue: !0,
        autoQueue: !0,
        addRemoveLinks: !1,
        previewsContainer: null,
        disablePreviews: !1,
        hiddenInputContainer: "body",
        capture: null,
        renameFilename: null,
        renameFile: null,
        forceFallback: !1,
        dictDefaultMessage: "Drop files here to upload",
        dictFallbackMessage:
            "Your browser does not support drag'n'drop file uploads.",
        dictFallbackText:
            "Please use the fallback form below to upload your files like in the olden days.",
        dictFileTooBig:
            "File is too big ({{filesize}}MiB). Max filesize: {{maxFilesize}}MiB.",
        dictInvalidFileType: "You can't upload files of this type.",
        dictResponseError: "Server responded with {{statusCode}} code.",
        dictCancelUpload: "Cancel upload",
        dictUploadCanceled: "Upload canceled.",
        dictCancelUploadConfirmation:
            "Are you sure you want to cancel this upload?",
        dictRemoveFile: "Remove file",
        dictRemoveFileConfirmation: null,
        dictMaxFilesExceeded: "You can not upload any more files.",
        dictFileSizeUnits: { tb: "TB", gb: "GB", mb: "MB", kb: "KB", b: "b" },
        init: function () { },
        params: function (e, t, i) {
            if (i)
                return {
                    dzuuid: i.file.upload.uuid,
                    dzchunkindex: i.index,
                    dztotalfilesize: i.file.size,
                    dzchunksize: this.options.chunkSize,
                    dztotalchunkcount: i.file.upload.totalChunkCount,
                    dzchunkbyteoffset: i.index * this.options.chunkSize,
                };
        },
        accept: function (e, t) {
            return t();
        },
        chunksUploaded: function (e, t) {
            t();
        },
        binaryBody: !1,
        fallback: function () {
            var e;
            this.element.className = "".concat(
                this.element.className,
                " dz-browser-not-supported"
            );
            var t = !0,
                i = !1,
                n = void 0;
            try {
                for (
                    var r,
                    a = this.element.getElementsByTagName("div")[Symbol.iterator]();
                    !(t = (r = a.next()).done);
                    t = !0
                ) {
                    var o = r.value;
                    if (/(^| )dz-message($| )/.test(o.className)) {
                        (e = o), (o.className = "dz-message");
                        break;
                    }
                }
            } catch (e) {
                (i = !0), (n = e);
            } finally {
                try {
                    t || null == a.return || a.return();
                } finally {
                    if (i) throw n;
                }
            }
            e ||
                ((e = f.createElement('<div class="dz-message"><span></span></div>')),
                    this.element.appendChild(e));
            var l = e.getElementsByTagName("span")[0];
            return (
                l &&
                (null != l.textContent
                    ? (l.textContent = this.options.dictFallbackMessage)
                    : null != l.innerText &&
                    (l.innerText = this.options.dictFallbackMessage)),
                this.element.appendChild(this.getFallbackForm())
            );
        },
        resize: function (e, t, i, n) {
            var r = { srcX: 0, srcY: 0, srcWidth: e.width, srcHeight: e.height },
                a = e.width / e.height;
            null == t && null == i
                ? ((t = r.srcWidth), (i = r.srcHeight))
                : null == t
                    ? (t = i * a)
                    : null == i && (i = t / a);
            var o = (t = Math.min(t, r.srcWidth)) / (i = Math.min(i, r.srcHeight));
            if (r.srcWidth > t || r.srcHeight > i)
                if ("crop" === n)
                    a > o
                        ? ((r.srcHeight = e.height), (r.srcWidth = r.srcHeight * o))
                        : ((r.srcWidth = e.width), (r.srcHeight = r.srcWidth / o));
                else {
                    if ("contain" !== n)
                        throw new Error("Unknown resizeMethod '".concat(n, "'"));
                    a > o ? (i = t / a) : (t = i * a);
                }
            return (
                (r.srcX = (e.width - r.srcWidth) / 2),
                (r.srcY = (e.height - r.srcHeight) / 2),
                (r.trgWidth = t),
                (r.trgHeight = i),
                r
            );
        },
        transformFile: function (e, t) {
            return (this.options.resizeWidth || this.options.resizeHeight) &&
                e.type.match(/image.*/)
                ? this.resizeImage(
                    e,
                    this.options.resizeWidth,
                    this.options.resizeHeight,
                    this.options.resizeMethod,
                    t
                )
                : t(e);
        },
        previewTemplate: e(
            '<div class="dz-file-preview dz-preview"> <div class="dz-image"><img data-dz-thumbnail=""></div> <div class="dz-details"> <div class="dz-size"><span data-dz-size=""></span></div> <div class="dz-filename"><span data-dz-name=""></span></div> </div> <div class="dz-progress"> <span class="dz-upload" data-dz-uploadprogress=""></span> </div> <div class="dz-error-message"><span data-dz-errormessage=""></span></div> <div class="dz-success-mark"> <svg width="54" height="54" fill="#fff"><path d="m10.207 29.793 4.086-4.086a1 1 0 0 1 1.414 0l5.586 5.586a1 1 0 0 0 1.414 0l15.586-15.586a1 1 0 0 1 1.414 0l4.086 4.086a1 1 0 0 1 0 1.414L22.707 42.293a1 1 0 0 1-1.414 0L10.207 31.207a1 1 0 0 1 0-1.414Z"/></svg> </div> <div class="dz-error-mark"> <svg width="54" height="54" fill="#fff"><path d="m26.293 20.293-7.086-7.086a1 1 0 0 0-1.414 0l-4.586 4.586a1 1 0 0 0 0 1.414l7.086 7.086a1 1 0 0 1 0 1.414l-7.086 7.086a1 1 0 0 0 0 1.414l4.586 4.586a1 1 0 0 0 1.414 0l7.086-7.086a1 1 0 0 1 1.414 0l7.086 7.086a1 1 0 0 0 1.414 0l4.586-4.586a1 1 0 0 0 0-1.414l-7.086-7.086a1 1 0 0 1 0-1.414l7.086-7.086a1 1 0 0 0 0-1.414l-4.586-4.586a1 1 0 0 0-1.414 0l-7.086 7.086a1 1 0 0 1-1.414 0Z"/></svg> </div> </div>'
        ),
        drop: function (e) {
            return this.element.classList.remove("dz-drag-hover");
        },
        dragstart: function (e) { },
        dragend: function (e) {
            return this.element.classList.remove("dz-drag-hover");
        },
        dragenter: function (e) {
            return this.element.classList.add("dz-drag-hover");
        },
        dragover: function (e) {
            return this.element.classList.add("dz-drag-hover");
        },
        dragleave: function (e) {
            return this.element.classList.remove("dz-drag-hover");
        },
        paste: function (e) { },
        reset: function () {
            return this.element.classList.remove("dz-started");
        },
        addedfile: function (e) {
            if (
                (this.element === this.previewsContainer &&
                    this.element.classList.add("dz-started"),
                    this.previewsContainer && !this.options.disablePreviews)
            ) {
                var t = this;
                (e.previewElement = f.createElement(
                    this.options.previewTemplate.trim()
                )),
                    (e.previewTemplate = e.previewElement),
                    this.previewsContainer.appendChild(e.previewElement);
                var i = !0,
                    n = !1,
                    r = void 0;
                try {
                    for (
                        var a,
                        o = e.previewElement
                            .querySelectorAll("[data-dz-name]")
                        [Symbol.iterator]();
                        !(i = (a = o.next()).done);
                        i = !0
                    ) {
                        var l = a.value;
                        l.textContent = e.name;
                    }
                } catch (e) {
                    (n = !0), (r = e);
                } finally {
                    try {
                        i || null == o.return || o.return();
                    } finally {
                        if (n) throw r;
                    }
                }
                var s = !0,
                    u = !1,
                    c = void 0;
                try {
                    for (
                        var d,
                        h = e.previewElement
                            .querySelectorAll("[data-dz-size]")
                        [Symbol.iterator]();
                        !(s = (d = h.next()).done);
                        s = !0
                    )
                        (l = d.value).innerHTML = this.filesize(e.size);
                } catch (e) {
                    (u = !0), (c = e);
                } finally {
                    try {
                        s || null == h.return || h.return();
                    } finally {
                        if (u) throw c;
                    }
                }
                this.options.addRemoveLinks &&
                    ((e._removeLink = f.createElement(
                        '<a class="dz-remove" href="javascript:undefined;" data-dz-remove>'.concat(
                            this.options.dictRemoveFile,
                            "</a>"
                        )
                    )),
                        e.previewElement.appendChild(e._removeLink));
                var p = function (i) {
                    var n = t;
                    if (
                        (i.preventDefault(),
                            i.stopPropagation(),
                            e.status === f.UPLOADING)
                    )
                        return f.confirm(
                            t.options.dictCancelUploadConfirmation,
                            function () {
                                return n.removeFile(e);
                            }
                        );
                    var r = t;
                    return t.options.dictRemoveFileConfirmation
                        ? f.confirm(t.options.dictRemoveFileConfirmation, function () {
                            return r.removeFile(e);
                        })
                        : t.removeFile(e);
                },
                    m = !0,
                    v = !1,
                    y = void 0;
                try {
                    for (
                        var g,
                        b = e.previewElement
                            .querySelectorAll("[data-dz-remove]")
                        [Symbol.iterator]();
                        !(m = (g = b.next()).done);
                        m = !0
                    ) {
                        g.value.addEventListener("click", p);
                    }
                } catch (e) {
                    (v = !0), (y = e);
                } finally {
                    try {
                        m || null == b.return || b.return();
                    } finally {
                        if (v) throw y;
                    }
                }
            }
        },
        removedfile: function (e) {
            return (
                null != e.previewElement &&
                null != e.previewElement.parentNode &&
                e.previewElement.parentNode.removeChild(e.previewElement),
                this._updateMaxFilesReachedClass()
            );
        },
        thumbnail: function (e, t) {
            if (e.previewElement) {
                e.previewElement.classList.remove("dz-file-preview");
                var i = !0,
                    n = !1,
                    r = void 0;
                try {
                    for (
                        var a,
                        o = e.previewElement
                            .querySelectorAll("[data-dz-thumbnail]")
                        [Symbol.iterator]();
                        !(i = (a = o.next()).done);
                        i = !0
                    ) {
                        var l = a.value;
                        (l.alt = e.name), (l.src = t);
                    }
                } catch (e) {
                    (n = !0), (r = e);
                } finally {
                    try {
                        i || null == o.return || o.return();
                    } finally {
                        if (n) throw r;
                    }
                }
                return setTimeout(function () {
                    return e.previewElement.classList.add("dz-image-preview");
                }, 1);
            }
        },
        error: function (e, t) {
            if (e.previewElement) {
                e.previewElement.classList.add("dz-error"),
                    "string" != typeof t && t.error && (t = t.error);
                var i = !0,
                    n = !1,
                    r = void 0;
                try {
                    for (
                        var a,
                        o = e.previewElement
                            .querySelectorAll("[data-dz-errormessage]")
                        [Symbol.iterator]();
                        !(i = (a = o.next()).done);
                        i = !0
                    ) {
                        a.value.textContent = t;
                    }
                } catch (e) {
                    (n = !0), (r = e);
                } finally {
                    try {
                        i || null == o.return || o.return();
                    } finally {
                        if (n) throw r;
                    }
                }
            }
        },
        errormultiple: function () { },
        processing: function (e) {
            if (
                e.previewElement &&
                (e.previewElement.classList.add("dz-processing"), e._removeLink)
            )
                return (e._removeLink.innerHTML = this.options.dictCancelUpload);
        },
        processingmultiple: function () { },
        uploadprogress: function (e, t, i) {
            var n = !0,
                r = !1,
                a = void 0;
            if (e.previewElement)
                try {
                    for (
                        var o,
                        l = e.previewElement
                            .querySelectorAll("[data-dz-uploadprogress]")
                        [Symbol.iterator]();
                        !(n = (o = l.next()).done);
                        n = !0
                    ) {
                        var s = o.value;
                        "PROGRESS" === s.nodeName
                            ? (s.value = t)
                            : (s.style.width = "".concat(t, "%"));
                    }
                } catch (e) {
                    (r = !0), (a = e);
                } finally {
                    try {
                        n || null == l.return || l.return();
                    } finally {
                        if (r) throw a;
                    }
                }
        },
        totaluploadprogress: function () { },
        sending: function () { },
        sendingmultiple: function () { },
        success: function (e) {
            if (e.previewElement)
                return e.previewElement.classList.add("dz-success");
        },
        successmultiple: function () { },
        canceled: function (e) {
            return this.emit("error", e, this.options.dictUploadCanceled);
        },
        canceledmultiple: function () { },
        complete: function (e) {
            if (
                (e._removeLink &&
                    (e._removeLink.innerHTML = this.options.dictRemoveFile),
                    e.previewElement)
            )
                return e.previewElement.classList.add("dz-complete");
        },
        completemultiple: function () { },
        maxfilesexceeded: function () { },
        maxfilesreached: function () { },
        queuecomplete: function () { },
        addedfiles: function () { },
    },
        f = (function (n) {
            "use strict";
            function o(n, r) {
                var l, c, d, h;
                if (
                    (i(this, o),
                        ((l = s(this, ((c = o), a(c)).call(this))).element = n),
                        (l.clickableElements = []),
                        (l.listeners = []),
                        (l.files = []),
                        "string" == typeof l.element &&
                        (l.element = document.querySelector(l.element)),
                        !l.element || null == l.element.nodeType)
                )
                    throw new Error("Invalid dropzone element.");
                if (l.element.dropzone) throw new Error("Dropzone already attached.");
                o.instances.push(t(l)), (l.element.dropzone = t(l));
                var f = null != (h = o.optionsForElement(l.element)) ? h : {};
                if (
                    ((l.options = e(u)(!0, {}, p, f, null != r ? r : {})),
                        (l.options.previewTemplate = l.options.previewTemplate.replace(
                            /\n*/g,
                            ""
                        )),
                        l.options.forceFallback || !o.isBrowserSupported())
                )
                    return s(l, l.options.fallback.call(t(l)));
                if (
                    (null == l.options.url &&
                        (l.options.url = l.element.getAttribute("action")),
                        !l.options.url)
                )
                    throw new Error("No URL provided.");
                if (l.options.acceptedFiles && l.options.acceptedMimeTypes)
                    throw new Error(
                        "You can't provide both 'acceptedFiles' and 'acceptedMimeTypes'. 'acceptedMimeTypes' is deprecated."
                    );
                if (l.options.uploadMultiple && l.options.chunking)
                    throw new Error("You cannot set both: uploadMultiple and chunking.");
                if (l.options.binaryBody && l.options.uploadMultiple)
                    throw new Error(
                        "You cannot set both: binaryBody and uploadMultiple."
                    );
                return (
                    l.options.acceptedMimeTypes &&
                    ((l.options.acceptedFiles = l.options.acceptedMimeTypes),
                        delete l.options.acceptedMimeTypes),
                    null != l.options.renameFilename &&
                    (l.options.renameFile = function (e) {
                        return l.options.renameFilename.call(t(l), e.name, e);
                    }),
                    "string" == typeof l.options.method &&
                    (l.options.method = l.options.method.toUpperCase()),
                    (d = l.getExistingFallback()) &&
                    d.parentNode &&
                    d.parentNode.removeChild(d),
                    !1 !== l.options.previewsContainer &&
                    (l.options.previewsContainer
                        ? (l.previewsContainer = o.getElement(
                            l.options.previewsContainer,
                            "previewsContainer"
                        ))
                        : (l.previewsContainer = l.element)),
                    l.options.clickable &&
                    (!0 === l.options.clickable
                        ? (l.clickableElements = [l.element])
                        : (l.clickableElements = o.getElements(
                            l.options.clickable,
                            "clickable"
                        ))),
                    l.init(),
                    l
                );
            }
            return (
                l(o, n),
                r(
                    o,
                    [
                        {
                            key: "getAcceptedFiles",
                            value: function () {
                                return this.files
                                    .filter(function (e) {
                                        return e.accepted;
                                    })
                                    .map(function (e) {
                                        return e;
                                    });
                            },
                        },
                        {
                            key: "getRejectedFiles",
                            value: function () {
                                return this.files
                                    .filter(function (e) {
                                        return !e.accepted;
                                    })
                                    .map(function (e) {
                                        return e;
                                    });
                            },
                        },
                        {
                            key: "getFilesWithStatus",
                            value: function (e) {
                                return this.files
                                    .filter(function (t) {
                                        return t.status === e;
                                    })
                                    .map(function (e) {
                                        return e;
                                    });
                            },
                        },
                        {
                            key: "getQueuedFiles",
                            value: function () {
                                return this.getFilesWithStatus(o.QUEUED);
                            },
                        },
                        {
                            key: "getUploadingFiles",
                            value: function () {
                                return this.getFilesWithStatus(o.UPLOADING);
                            },
                        },
                        {
                            key: "getAddedFiles",
                            value: function () {
                                return this.getFilesWithStatus(o.ADDED);
                            },
                        },
                        {
                            key: "getActiveFiles",
                            value: function () {
                                return this.files
                                    .filter(function (e) {
                                        return e.status === o.UPLOADING || e.status === o.QUEUED;
                                    })
                                    .map(function (e) {
                                        return e;
                                    });
                            },
                        },
                        {
                            key: "init",
                            value: function () {
                                var e = this,
                                    t = this,
                                    i = this,
                                    n = this,
                                    r = this,
                                    a = this,
                                    l = this,
                                    s = this,
                                    u = this,
                                    c = this,
                                    d = this;
                                if (
                                    ("form" === this.element.tagName &&
                                        this.element.setAttribute("enctype", "multipart/form-data"),
                                        this.element.classList.contains("dropzone") &&
                                        !this.element.querySelector(".dz-message") &&
                                        this.element.appendChild(
                                            o.createElement(
                                                '<div class="dz-default dz-message"><button class="dz-button" type="button">'.concat(
                                                    this.options.dictDefaultMessage,
                                                    "</button></div>"
                                                )
                                            )
                                        ),
                                        this.clickableElements.length)
                                ) {
                                    var h = this,
                                        p = function () {
                                            var e = h;
                                            h.hiddenFileInput &&
                                                h.hiddenFileInput.parentNode.removeChild(
                                                    h.hiddenFileInput
                                                ),
                                                (h.hiddenFileInput = document.createElement("input")),
                                                h.hiddenFileInput.setAttribute("type", "file"),
                                                (null === h.options.maxFiles ||
                                                    h.options.maxFiles > 1) &&
                                                h.hiddenFileInput.setAttribute(
                                                    "multiple",
                                                    "multiple"
                                                ),
                                                (h.hiddenFileInput.className = "dz-hidden-input"),
                                                null !== h.options.acceptedFiles &&
                                                h.hiddenFileInput.setAttribute(
                                                    "accept",
                                                    h.options.acceptedFiles
                                                ),
                                                null !== h.options.capture &&
                                                h.hiddenFileInput.setAttribute(
                                                    "capture",
                                                    h.options.capture
                                                ),
                                                h.hiddenFileInput.setAttribute("tabindex", "-1"),
                                                (h.hiddenFileInput.style.visibility = "hidden"),
                                                (h.hiddenFileInput.style.position = "absolute"),
                                                (h.hiddenFileInput.style.top = "0"),
                                                (h.hiddenFileInput.style.left = "0"),
                                                (h.hiddenFileInput.style.height = "0"),
                                                (h.hiddenFileInput.style.width = "0"),
                                                o
                                                    .getElement(
                                                        h.options.hiddenInputContainer,
                                                        "hiddenInputContainer"
                                                    )
                                                    .appendChild(h.hiddenFileInput),
                                                h.hiddenFileInput.addEventListener(
                                                    "change",
                                                    function () {
                                                        var t = e.hiddenFileInput.files,
                                                            i = !0,
                                                            n = !1,
                                                            r = void 0;
                                                        if (t.length)
                                                            try {
                                                                for (
                                                                    var a, o = t[Symbol.iterator]();
                                                                    !(i = (a = o.next()).done);
                                                                    i = !0
                                                                ) {
                                                                    var l = a.value;
                                                                    e.addFile(l);
                                                                }
                                                            } catch (e) {
                                                                (n = !0), (r = e);
                                                            } finally {
                                                                try {
                                                                    i || null == o.return || o.return();
                                                                } finally {
                                                                    if (n) throw r;
                                                                }
                                                            }
                                                        e.emit("addedfiles", t), p();
                                                    }
                                                );
                                        };
                                    p();
                                }
                                this.URL = null !== window.URL ? window.URL : window.webkitURL;
                                var f = !0,
                                    m = !1,
                                    v = void 0;
                                try {
                                    for (
                                        var y, g = this.events[Symbol.iterator]();
                                        !(f = (y = g.next()).done);
                                        f = !0
                                    ) {
                                        var b = y.value;
                                        this.on(b, this.options[b]);
                                    }
                                } catch (e) {
                                    (m = !0), (v = e);
                                } finally {
                                    try {
                                        f || null == g.return || g.return();
                                    } finally {
                                        if (m) throw v;
                                    }
                                }
                                this.on("uploadprogress", function () {
                                    return e.updateTotalUploadProgress();
                                }),
                                    this.on("removedfile", function () {
                                        return t.updateTotalUploadProgress();
                                    }),
                                    this.on("canceled", function (e) {
                                        return i.emit("complete", e);
                                    }),
                                    this.on("complete", function (e) {
                                        var t = n;
                                        if (
                                            0 === n.getAddedFiles().length &&
                                            0 === n.getUploadingFiles().length &&
                                            0 === n.getQueuedFiles().length
                                        )
                                            return setTimeout(function () {
                                                return t.emit("queuecomplete");
                                            }, 0);
                                    });
                                var k = function (e) {
                                    if (
                                        (function (e) {
                                            if (e.dataTransfer.types)
                                                for (var t = 0; t < e.dataTransfer.types.length; t++)
                                                    if ("Files" === e.dataTransfer.types[t]) return !0;
                                            return !1;
                                        })(e)
                                    )
                                        return (
                                            e.stopPropagation(),
                                            e.preventDefault
                                                ? e.preventDefault()
                                                : (e.returnValue = !1)
                                        );
                                };
                                return (
                                    (this.listeners = [
                                        {
                                            element: this.element,
                                            events: {
                                                dragstart: function (e) {
                                                    return r.emit("dragstart", e);
                                                },
                                                dragenter: function (e) {
                                                    return k(e), a.emit("dragenter", e);
                                                },
                                                dragover: function (e) {
                                                    var t;
                                                    try {
                                                        t = e.dataTransfer.effectAllowed;
                                                    } catch (e) { }
                                                    return (
                                                        (e.dataTransfer.dropEffect =
                                                            "move" === t || "linkMove" === t
                                                                ? "move"
                                                                : "copy"),
                                                        k(e),
                                                        l.emit("dragover", e)
                                                    );
                                                },
                                                dragleave: function (e) {
                                                    return s.emit("dragleave", e);
                                                },
                                                drop: function (e) {
                                                    return k(e), u.drop(e);
                                                },
                                                dragend: function (e) {
                                                    return c.emit("dragend", e);
                                                },
                                            },
                                        },
                                    ]),
                                    this.clickableElements.forEach(function (e) {
                                        var t = d;
                                        return d.listeners.push({
                                            element: e,
                                            events: {
                                                click: function (i) {
                                                    return (
                                                        (e !== t.element ||
                                                            i.target === t.element ||
                                                            o.elementInside(
                                                                i.target,
                                                                t.element.querySelector(".dz-message")
                                                            )) &&
                                                        t.hiddenFileInput.click(),
                                                        !0
                                                    );
                                                },
                                            },
                                        });
                                    }),
                                    this.enable(),
                                    this.options.init.call(this)
                                );
                            },
                        },
                        {
                            key: "destroy",
                            value: function () {
                                return (
                                    this.disable(),
                                    this.removeAllFiles(!0),
                                    (null != this.hiddenFileInput
                                        ? this.hiddenFileInput.parentNode
                                        : void 0) &&
                                    (this.hiddenFileInput.parentNode.removeChild(
                                        this.hiddenFileInput
                                    ),
                                        (this.hiddenFileInput = null)),
                                    delete this.element.dropzone,
                                    o.instances.splice(o.instances.indexOf(this), 1)
                                );
                            },
                        },
                        {
                            key: "updateTotalUploadProgress",
                            value: function () {
                                var e,
                                    t = 0,
                                    i = 0;
                                if (this.getActiveFiles().length) {
                                    var n = !0,
                                        r = !1,
                                        a = void 0;
                                    try {
                                        for (
                                            var o, l = this.getActiveFiles()[Symbol.iterator]();
                                            !(n = (o = l.next()).done);
                                            n = !0
                                        ) {
                                            var s = o.value;
                                            (t += s.upload.bytesSent), (i += s.upload.total);
                                        }
                                    } catch (e) {
                                        (r = !0), (a = e);
                                    } finally {
                                        try {
                                            n || null == l.return || l.return();
                                        } finally {
                                            if (r) throw a;
                                        }
                                    }
                                    e = (100 * t) / i;
                                } else e = 100;
                                return this.emit("totaluploadprogress", e, i, t);
                            },
                        },
                        {
                            key: "_getParamName",
                            value: function (e) {
                                return "function" == typeof this.options.paramName
                                    ? this.options.paramName(e)
                                    : ""
                                        .concat(this.options.paramName)
                                        .concat(
                                            this.options.uploadMultiple ? "[".concat(e, "]") : ""
                                        );
                            },
                        },
                        {
                            key: "_renameFile",
                            value: function (e) {
                                return "function" != typeof this.options.renameFile
                                    ? e.name
                                    : this.options.renameFile(e);
                            },
                        },
                        {
                            key: "getFallbackForm",
                            value: function () {
                                var e, t;
                                if ((e = this.getExistingFallback())) return e;
                                var i = '<div class="dz-fallback">';
                                this.options.dictFallbackText &&
                                    (i += "<p>".concat(this.options.dictFallbackText, "</p>")),
                                    (i += '<input type="file" name="'
                                        .concat(this._getParamName(0), '" ')
                                        .concat(
                                            this.options.uploadMultiple
                                                ? 'multiple="multiple"'
                                                : void 0,
                                            ' /><input type="submit" value="Upload!"></div>'
                                        ));
                                var n = o.createElement(i);
                                return (
                                    "FORM" !== this.element.tagName
                                        ? (t = o.createElement(
                                            '<form action="'
                                                .concat(
                                                    this.options.url,
                                                    '" enctype="multipart/form-data" method="'
                                                )
                                                .concat(this.options.method, '"></form>')
                                        )).appendChild(n)
                                        : (this.element.setAttribute(
                                            "enctype",
                                            "multipart/form-data"
                                        ),
                                            this.element.setAttribute("method", this.options.method)),
                                    null != t ? t : n
                                );
                            },
                        },
                        {
                            key: "getExistingFallback",
                            value: function () {
                                var e = function (e) {
                                    var t = !0,
                                        i = !1,
                                        n = void 0;
                                    try {
                                        for (
                                            var r, a = e[Symbol.iterator]();
                                            !(t = (r = a.next()).done);
                                            t = !0
                                        ) {
                                            var o = r.value;
                                            if (/(^| )fallback($| )/.test(o.className)) return o;
                                        }
                                    } catch (e) {
                                        (i = !0), (n = e);
                                    } finally {
                                        try {
                                            t || null == a.return || a.return();
                                        } finally {
                                            if (i) throw n;
                                        }
                                    }
                                },
                                    t = !0,
                                    i = !1,
                                    n = void 0;
                                try {
                                    for (
                                        var r, a = ["div", "form"][Symbol.iterator]();
                                        !(t = (r = a.next()).done);
                                        t = !0
                                    ) {
                                        var o,
                                            l = r.value;
                                        if ((o = e(this.element.getElementsByTagName(l)))) return o;
                                    }
                                } catch (e) {
                                    (i = !0), (n = e);
                                } finally {
                                    try {
                                        t || null == a.return || a.return();
                                    } finally {
                                        if (i) throw n;
                                    }
                                }
                            },
                        },
                        {
                            key: "setupEventListeners",
                            value: function () {
                                return this.listeners.map(function (e) {
                                    return (function () {
                                        var t = [];
                                        for (var i in e.events) {
                                            var n = e.events[i];
                                            t.push(e.element.addEventListener(i, n, !1));
                                        }
                                        return t;
                                    })();
                                });
                            },
                        },
                        {
                            key: "removeEventListeners",
                            value: function () {
                                return this.listeners.map(function (e) {
                                    return (function () {
                                        var t = [];
                                        for (var i in e.events) {
                                            var n = e.events[i];
                                            t.push(e.element.removeEventListener(i, n, !1));
                                        }
                                        return t;
                                    })();
                                });
                            },
                        },
                        {
                            key: "disable",
                            value: function () {
                                var e = this;
                                return (
                                    this.clickableElements.forEach(function (e) {
                                        return e.classList.remove("dz-clickable");
                                    }),
                                    this.removeEventListeners(),
                                    (this.disabled = !0),
                                    this.files.map(function (t) {
                                        return e.cancelUpload(t);
                                    })
                                );
                            },
                        },
                        {
                            key: "enable",
                            value: function () {
                                return (
                                    delete this.disabled,
                                    this.clickableElements.forEach(function (e) {
                                        return e.classList.add("dz-clickable");
                                    }),
                                    this.setupEventListeners()
                                );
                            },
                        },
                        {
                            key: "filesize",
                            value: function (e) {
                                var t = 0,
                                    i = "b";
                                if (e > 0) {
                                    for (
                                        var n = ["tb", "gb", "mb", "kb", "b"], r = 0;
                                        r < n.length;
                                        r++
                                    ) {
                                        var a = n[r];
                                        if (e >= Math.pow(this.options.filesizeBase, 4 - r) / 10) {
                                            (t = e / Math.pow(this.options.filesizeBase, 4 - r)),
                                                (i = a);
                                            break;
                                        }
                                    }
                                    t = Math.round(10 * t) / 10;
                                }
                                return "<strong>"
                                    .concat(t, "</strong> ")
                                    .concat(this.options.dictFileSizeUnits[i]);
                            },
                        },
                        {
                            key: "_updateMaxFilesReachedClass",
                            value: function () {
                                return null != this.options.maxFiles &&
                                    this.getAcceptedFiles().length >= this.options.maxFiles
                                    ? (this.getAcceptedFiles().length === this.options.maxFiles &&
                                        this.emit("maxfilesreached", this.files),
                                        this.element.classList.add("dz-max-files-reached"))
                                    : this.element.classList.remove("dz-max-files-reached");
                            },
                        },
                        {
                            key: "drop",
                            value: function (e) {
                                if (e.dataTransfer) {
                                    this.emit("drop", e);
                                    for (var t = [], i = 0; i < e.dataTransfer.files.length; i++)
                                        t[i] = e.dataTransfer.files[i];
                                    if (t.length) {
                                        var n = e.dataTransfer.items;
                                        n && n.length && null != n[0].webkitGetAsEntry
                                            ? this._addFilesFromItems(n)
                                            : this.handleFiles(t);
                                    }
                                    this.emit("addedfiles", t);
                                }
                            },
                        },
                        {
                            key: "paste",
                            value: function (e) {
                                if (
                                    null !=
                                    ((t = null != e ? e.clipboardData : void 0),
                                        (i = function (e) {
                                            return e.items;
                                        }),
                                        null != t ? i(t) : void 0)
                                ) {
                                    var t, i;
                                    this.emit("paste", e);
                                    var n = e.clipboardData.items;
                                    return n.length ? this._addFilesFromItems(n) : void 0;
                                }
                            },
                        },
                        {
                            key: "handleFiles",
                            value: function (e) {
                                var t = !0,
                                    i = !1,
                                    n = void 0;
                                try {
                                    for (
                                        var r, a = e[Symbol.iterator]();
                                        !(t = (r = a.next()).done);
                                        t = !0
                                    ) {
                                        var o = r.value;
                                        this.addFile(o);
                                    }
                                } catch (e) {
                                    (i = !0), (n = e);
                                } finally {
                                    try {
                                        t || null == a.return || a.return();
                                    } finally {
                                        if (i) throw n;
                                    }
                                }
                            },
                        },
                        {
                            key: "_addFilesFromItems",
                            value: function (e) {
                                var t = this;
                                return (function () {
                                    var i = [],
                                        n = !0,
                                        r = !1,
                                        a = void 0;
                                    try {
                                        for (
                                            var o, l = e[Symbol.iterator]();
                                            !(n = (o = l.next()).done);
                                            n = !0
                                        ) {
                                            var s,
                                                u = o.value;
                                            null != u.webkitGetAsEntry && (s = u.webkitGetAsEntry())
                                                ? s.isFile
                                                    ? i.push(t.addFile(u.getAsFile()))
                                                    : s.isDirectory
                                                        ? i.push(t._addFilesFromDirectory(s, s.name))
                                                        : i.push(void 0)
                                                : null != u.getAsFile &&
                                                    (null == u.kind || "file" === u.kind)
                                                    ? i.push(t.addFile(u.getAsFile()))
                                                    : i.push(void 0);
                                        }
                                    } catch (e) {
                                        (r = !0), (a = e);
                                    } finally {
                                        try {
                                            n || null == l.return || l.return();
                                        } finally {
                                            if (r) throw a;
                                        }
                                    }
                                    return i;
                                })();
                            },
                        },
                        {
                            key: "_addFilesFromDirectory",
                            value: function (e, t) {
                                var i = this,
                                    n = e.createReader(),
                                    r = function (e) {
                                        return (
                                            (t = console),
                                            (i = "log"),
                                            (n = function (t) {
                                                return t.log(e);
                                            }),
                                            null != t && "function" == typeof t[i] ? n(t, i) : void 0
                                        );
                                        var t, i, n;
                                    },
                                    a = function () {
                                        var e = i;
                                        return n.readEntries(function (i) {
                                            if (i.length > 0) {
                                                var n = !0,
                                                    r = !1,
                                                    o = void 0;
                                                try {
                                                    for (
                                                        var l, s = i[Symbol.iterator]();
                                                        !(n = (l = s.next()).done);
                                                        n = !0
                                                    ) {
                                                        var u = l.value,
                                                            c = e;
                                                        u.isFile
                                                            ? u.file(function (e) {
                                                                if (
                                                                    !c.options.ignoreHiddenFiles ||
                                                                    "." !== e.name.substring(0, 1)
                                                                )
                                                                    return (
                                                                        (e.fullPath = ""
                                                                            .concat(t, "/")
                                                                            .concat(e.name)),
                                                                        c.addFile(e)
                                                                    );
                                                            })
                                                            : u.isDirectory &&
                                                            e._addFilesFromDirectory(
                                                                u,
                                                                "".concat(t, "/").concat(u.name)
                                                            );
                                                    }
                                                } catch (e) {
                                                    (r = !0), (o = e);
                                                } finally {
                                                    try {
                                                        n || null == s.return || s.return();
                                                    } finally {
                                                        if (r) throw o;
                                                    }
                                                }
                                                a();
                                            }
                                            return null;
                                        }, r);
                                    };
                                return a();
                            },
                        },
                        {
                            key: "accept",
                            value: function (e, t) {
                                this.options.maxFilesize &&
                                    e.size > 1048576 * this.options.maxFilesize
                                    ? t(
                                        this.options.dictFileTooBig
                                            .replace(
                                                "{{filesize}}",
                                                Math.round(e.size / 1024 / 10.24) / 100
                                            )
                                            .replace("{{maxFilesize}}", this.options.maxFilesize)
                                    )
                                    : o.isValidFile(e, this.options.acceptedFiles)
                                        ? null != this.options.maxFiles &&
                                            this.getAcceptedFiles().length >= this.options.maxFiles
                                            ? (t(
                                                this.options.dictMaxFilesExceeded.replace(
                                                    "{{maxFiles}}",
                                                    this.options.maxFiles
                                                )
                                            ),
                                                this.emit("maxfilesexceeded", e))
                                            : this.options.accept.call(this, e, t)
                                        : t(this.options.dictInvalidFileType);
                            },
                        },
                        {
                            key: "addFile",
                            value: function (e) {
                                var t = this;
                                (e.upload = {
                                    uuid: o.uuidv4(),
                                    progress: 0,
                                    total: e.size,
                                    bytesSent: 0,
                                    filename: this._renameFile(e),
                                }),
                                    this.files.push(e),
                                    (e.status = o.ADDED),
                                    this.emit("addedfile", e),
                                    this._enqueueThumbnail(e),
                                    this.accept(e, function (i) {
                                        i
                                            ? ((e.accepted = !1), t._errorProcessing([e], i))
                                            : ((e.accepted = !0),
                                                t.options.autoQueue && t.enqueueFile(e)),
                                            t._updateMaxFilesReachedClass();
                                    });
                            },
                        },
                        {
                            key: "enqueueFiles",
                            value: function (e) {
                                var t = !0,
                                    i = !1,
                                    n = void 0;
                                try {
                                    for (
                                        var r, a = e[Symbol.iterator]();
                                        !(t = (r = a.next()).done);
                                        t = !0
                                    ) {
                                        var o = r.value;
                                        this.enqueueFile(o);
                                    }
                                } catch (e) {
                                    (i = !0), (n = e);
                                } finally {
                                    try {
                                        t || null == a.return || a.return();
                                    } finally {
                                        if (i) throw n;
                                    }
                                }
                                return null;
                            },
                        },
                        {
                            key: "enqueueFile",
                            value: function (e) {
                                if (e.status !== o.ADDED || !0 !== e.accepted)
                                    throw new Error(
                                        "This file can't be queued because it has already been processed or was rejected."
                                    );
                                var t = this;
                                if (((e.status = o.QUEUED), this.options.autoProcessQueue))
                                    return setTimeout(function () {
                                        return t.processQueue();
                                    }, 0);
                            },
                        },
                        {
                            key: "_enqueueThumbnail",
                            value: function (e) {
                                if (
                                    this.options.createImageThumbnails &&
                                    e.type.match(/image.*/) &&
                                    e.size <= 1048576 * this.options.maxThumbnailFilesize
                                ) {
                                    var t = this;
                                    return (
                                        this._thumbnailQueue.push(e),
                                        setTimeout(function () {
                                            return t._processThumbnailQueue();
                                        }, 0)
                                    );
                                }
                            },
                        },
                        {
                            key: "_processThumbnailQueue",
                            value: function () {
                                var e = this;
                                if (
                                    !this._processingThumbnail &&
                                    0 !== this._thumbnailQueue.length
                                ) {
                                    this._processingThumbnail = !0;
                                    var t = this._thumbnailQueue.shift();
                                    return this.createThumbnail(
                                        t,
                                        this.options.thumbnailWidth,
                                        this.options.thumbnailHeight,
                                        this.options.thumbnailMethod,
                                        !0,
                                        function (i) {
                                            return (
                                                e.emit("thumbnail", t, i),
                                                (e._processingThumbnail = !1),
                                                e._processThumbnailQueue()
                                            );
                                        }
                                    );
                                }
                            },
                        },
                        {
                            key: "removeFile",
                            value: function (e) {
                                if (
                                    (e.status === o.UPLOADING && this.cancelUpload(e),
                                        (this.files = m(this.files, e)),
                                        this.emit("removedfile", e),
                                        0 === this.files.length)
                                )
                                    return this.emit("reset");
                            },
                        },
                        {
                            key: "removeAllFiles",
                            value: function (e) {
                                null == e && (e = !1);
                                var t = !0,
                                    i = !1,
                                    n = void 0;
                                try {
                                    for (
                                        var r, a = this.files.slice()[Symbol.iterator]();
                                        !(t = (r = a.next()).done);
                                        t = !0
                                    ) {
                                        var l = r.value;
                                        (l.status !== o.UPLOADING || e) && this.removeFile(l);
                                    }
                                } catch (e) {
                                    (i = !0), (n = e);
                                } finally {
                                    try {
                                        t || null == a.return || a.return();
                                    } finally {
                                        if (i) throw n;
                                    }
                                }
                                return null;
                            },
                        },
                        {
                            key: "resizeImage",
                            value: function (e, t, i, n, r) {
                                var a = this;
                                return this.createThumbnail(e, t, i, n, !0, function (t, i) {
                                    if (null == i) return r(e);
                                    var n = a.options.resizeMimeType;
                                    null == n && (n = e.type);
                                    var l = i.toDataURL(n, a.options.resizeQuality);
                                    return (
                                        ("image/jpeg" !== n && "image/jpg" !== n) ||
                                        (l = g.restore(e.dataURL, l)),
                                        r(o.dataURItoBlob(l))
                                    );
                                });
                            },
                        },
                        {
                            key: "createThumbnail",
                            value: function (e, t, i, n, r, a) {
                                var o = this,
                                    l = new FileReader();
                                (l.onload = function () {
                                    (e.dataURL = l.result),
                                        "image/svg+xml" !== e.type
                                            ? o.createThumbnailFromUrl(e, t, i, n, r, a)
                                            : null != a && a(l.result);
                                }),
                                    l.readAsDataURL(e);
                            },
                        },
                        {
                            key: "displayExistingFile",
                            value: function (e, t, i, n, r) {
                                var a = void 0 === r || r;
                                if ((this.emit("addedfile", e), this.emit("complete", e), a)) {
                                    var o = this;
                                    (e.dataURL = t),
                                        this.createThumbnailFromUrl(
                                            e,
                                            this.options.thumbnailWidth,
                                            this.options.thumbnailHeight,
                                            this.options.thumbnailMethod,
                                            this.options.fixOrientation,
                                            function (t) {
                                                o.emit("thumbnail", e, t), i && i();
                                            },
                                            n
                                        );
                                } else this.emit("thumbnail", e, t), i && i();
                            },
                        },
                        {
                            key: "createThumbnailFromUrl",
                            value: function (e, t, i, n, r, a, o) {
                                var l = this,
                                    s = document.createElement("img");
                                return (
                                    o && (s.crossOrigin = o),
                                    (r =
                                        "from-image" !=
                                        getComputedStyle(document.body).imageOrientation && r),
                                    (s.onload = function () {
                                        var o = l,
                                            u = function (e) {
                                                return e(1);
                                            };
                                        return (
                                            "undefined" != typeof EXIF &&
                                            null !== EXIF &&
                                            r &&
                                            (u = function (e) {
                                                return EXIF.getData(s, function () {
                                                    return e(EXIF.getTag(this, "Orientation"));
                                                });
                                            }),
                                            u(function (r) {
                                                (e.width = s.width), (e.height = s.height);
                                                var l = o.options.resize.call(o, e, t, i, n),
                                                    u = document.createElement("canvas"),
                                                    c = u.getContext("2d");
                                                switch (
                                                ((u.width = l.trgWidth),
                                                    (u.height = l.trgHeight),
                                                    r > 4 &&
                                                    ((u.width = l.trgHeight), (u.height = l.trgWidth)),
                                                    r)
                                                ) {
                                                    case 2:
                                                        c.translate(u.width, 0), c.scale(-1, 1);
                                                        break;
                                                    case 3:
                                                        c.translate(u.width, u.height), c.rotate(Math.PI);
                                                        break;
                                                    case 4:
                                                        c.translate(0, u.height), c.scale(1, -1);
                                                        break;
                                                    case 5:
                                                        c.rotate(0.5 * Math.PI), c.scale(1, -1);
                                                        break;
                                                    case 6:
                                                        c.rotate(0.5 * Math.PI), c.translate(0, -u.width);
                                                        break;
                                                    case 7:
                                                        c.rotate(0.5 * Math.PI),
                                                            c.translate(u.height, -u.width),
                                                            c.scale(-1, 1);
                                                        break;
                                                    case 8:
                                                        c.rotate(-0.5 * Math.PI), c.translate(-u.height, 0);
                                                }
                                                y(
                                                    c,
                                                    s,
                                                    null != l.srcX ? l.srcX : 0,
                                                    null != l.srcY ? l.srcY : 0,
                                                    l.srcWidth,
                                                    l.srcHeight,
                                                    null != l.trgX ? l.trgX : 0,
                                                    null != l.trgY ? l.trgY : 0,
                                                    l.trgWidth,
                                                    l.trgHeight
                                                );
                                                var d = u.toDataURL("image/png");
                                                if (null != a) return a(d, u);
                                            })
                                        );
                                    }),
                                    null != a && (s.onerror = a),
                                    (s.src = e.dataURL)
                                );
                            },
                        },
                        {
                            key: "processQueue",
                            value: function () {
                                var e = this.options.parallelUploads,
                                    t = this.getUploadingFiles().length,
                                    i = t;
                                if (!(t >= e)) {
                                    var n = this.getQueuedFiles();
                                    if (n.length > 0) {
                                        if (this.options.uploadMultiple)
                                            return this.processFiles(n.slice(0, e - t));
                                        for (; i < e;) {
                                            if (!n.length) return;
                                            this.processFile(n.shift()), i++;
                                        }
                                    }
                                }
                            },
                        },
                        {
                            key: "processFile",
                            value: function (e) {
                                return this.processFiles([e]);
                            },
                        },
                        {
                            key: "processFiles",
                            value: function (e) {
                                var t = !0,
                                    i = !1,
                                    n = void 0;
                                try {
                                    for (
                                        var r, a = e[Symbol.iterator]();
                                        !(t = (r = a.next()).done);
                                        t = !0
                                    ) {
                                        var l = r.value;
                                        (l.processing = !0),
                                            (l.status = o.UPLOADING),
                                            this.emit("processing", l);
                                    }
                                } catch (e) {
                                    (i = !0), (n = e);
                                } finally {
                                    try {
                                        t || null == a.return || a.return();
                                    } finally {
                                        if (i) throw n;
                                    }
                                }
                                return (
                                    this.options.uploadMultiple &&
                                    this.emit("processingmultiple", e),
                                    this.uploadFiles(e)
                                );
                            },
                        },
                        {
                            key: "_getFilesWithXhr",
                            value: function (e) {
                                return this.files
                                    .filter(function (t) {
                                        return t.xhr === e;
                                    })
                                    .map(function (e) {
                                        return e;
                                    });
                            },
                        },
                        {
                            key: "cancelUpload",
                            value: function (e) {
                                if (e.status === o.UPLOADING) {
                                    var t = this._getFilesWithXhr(e.xhr),
                                        i = !0,
                                        n = !1,
                                        r = void 0;
                                    try {
                                        for (
                                            var a, l = t[Symbol.iterator]();
                                            !(i = (a = l.next()).done);
                                            i = !0
                                        ) {
                                            (p = a.value).status = o.CANCELED;
                                        }
                                    } catch (e) {
                                        (n = !0), (r = e);
                                    } finally {
                                        try {
                                            i || null == l.return || l.return();
                                        } finally {
                                            if (n) throw r;
                                        }
                                    }
                                    void 0 !== e.xhr && e.xhr.abort();
                                    var s = !0,
                                        u = !1,
                                        c = void 0;
                                    try {
                                        for (
                                            var d, h = t[Symbol.iterator]();
                                            !(s = (d = h.next()).done);
                                            s = !0
                                        ) {
                                            var p = d.value;
                                            this.emit("canceled", p);
                                        }
                                    } catch (e) {
                                        (u = !0), (c = e);
                                    } finally {
                                        try {
                                            s || null == h.return || h.return();
                                        } finally {
                                            if (u) throw c;
                                        }
                                    }
                                    this.options.uploadMultiple &&
                                        this.emit("canceledmultiple", t);
                                } else
                                    (e.status !== o.ADDED && e.status !== o.QUEUED) ||
                                        ((e.status = o.CANCELED),
                                            this.emit("canceled", e),
                                            this.options.uploadMultiple &&
                                            this.emit("canceledmultiple", [e]));
                                if (this.options.autoProcessQueue) return this.processQueue();
                            },
                        },
                        {
                            key: "resolveOption",
                            value: function (e) {
                                for (
                                    var t = arguments.length,
                                    i = new Array(t > 1 ? t - 1 : 0),
                                    n = 1;
                                    n < t;
                                    n++
                                )
                                    i[n - 1] = arguments[n];
                                return "function" == typeof e ? e.apply(this, i) : e;
                            },
                        },
                        {
                            key: "uploadFile",
                            value: function (e) {
                                return this.uploadFiles([e]);
                            },
                        },
                        {
                            key: "uploadFiles",
                            value: function (e) {
                                var t = this;
                                this._transformFiles(e, function (i) {
                                    if (t.options.chunking) {
                                        var n = i[0];
                                        (e[0].upload.chunked =
                                            t.options.chunking &&
                                            (t.options.forceChunking ||
                                                n.size > t.options.chunkSize)),
                                            (e[0].upload.totalChunkCount = Math.ceil(
                                                n.size / t.options.chunkSize
                                            ));
                                    }
                                    if (e[0].upload.chunked) {
                                        var r = t,
                                            a = t,
                                            l = e[0];
                                        n = i[0];
                                        l.upload.chunks = [];
                                        var s = function () {
                                            for (var t = 0; void 0 !== l.upload.chunks[t];) t++;
                                            if (!(t >= l.upload.totalChunkCount)) {
                                                0;
                                                var i = t * r.options.chunkSize,
                                                    a = Math.min(i + r.options.chunkSize, n.size),
                                                    s = {
                                                        name: r._getParamName(0),
                                                        data: n.webkitSlice
                                                            ? n.webkitSlice(i, a)
                                                            : n.slice(i, a),
                                                        filename: l.upload.filename,
                                                        chunkIndex: t,
                                                    };
                                                (l.upload.chunks[t] = {
                                                    file: l,
                                                    index: t,
                                                    dataBlock: s,
                                                    status: o.UPLOADING,
                                                    progress: 0,
                                                    retries: 0,
                                                }),
                                                    r._uploadData(e, [s]);
                                            }
                                        };
                                        if (
                                            ((l.upload.finishedChunkUpload = function (t, i) {
                                                var n = a,
                                                    r = !0;
                                                (t.status = o.SUCCESS),
                                                    (t.dataBlock = null),
                                                    (t.response = t.xhr.responseText),
                                                    (t.responseHeaders = t.xhr.getAllResponseHeaders()),
                                                    (t.xhr = null);
                                                for (var u = 0; u < l.upload.totalChunkCount; u++) {
                                                    if (void 0 === l.upload.chunks[u]) return s();
                                                    l.upload.chunks[u].status !== o.SUCCESS && (r = !1);
                                                }
                                                r &&
                                                    a.options.chunksUploaded(l, function () {
                                                        n._finished(e, i, null);
                                                    });
                                            }),
                                                t.options.parallelChunkUploads)
                                        )
                                            for (var u = 0; u < l.upload.totalChunkCount; u++) s();
                                        else s();
                                    } else {
                                        var c = [];
                                        for (u = 0; u < e.length; u++)
                                            c[u] = {
                                                name: t._getParamName(u),
                                                data: i[u],
                                                filename: e[u].upload.filename,
                                            };
                                        t._uploadData(e, c);
                                    }
                                });
                            },
                        },
                        {
                            key: "_getChunk",
                            value: function (e, t) {
                                for (var i = 0; i < e.upload.totalChunkCount; i++)
                                    if (
                                        void 0 !== e.upload.chunks[i] &&
                                        e.upload.chunks[i].xhr === t
                                    )
                                        return e.upload.chunks[i];
                            },
                        },
                        {
                            key: "_uploadData",
                            value: function (t, i) {
                                var n = this,
                                    r = this,
                                    a = this,
                                    o = this,
                                    l = new XMLHttpRequest(),
                                    s = !0,
                                    c = !1,
                                    d = void 0;
                                try {
                                    for (
                                        var h = t[Symbol.iterator]();
                                        !(s = (x = h.next()).done);
                                        s = !0
                                    ) {
                                        (g = x.value).xhr = l;
                                    }
                                } catch (e) {
                                    (c = !0), (d = e);
                                } finally {
                                    try {
                                        s || null == h.return || h.return();
                                    } finally {
                                        if (c) throw d;
                                    }
                                }
                                t[0].upload.chunked &&
                                    (t[0].upload.chunks[i[0].chunkIndex].xhr = l);
                                var p = this.resolveOption(this.options.method, t, i),
                                    f = this.resolveOption(this.options.url, t, i);
                                l.open(p, f, !0),
                                    this.resolveOption(this.options.timeout, t) &&
                                    (l.timeout = this.resolveOption(this.options.timeout, t)),
                                    (l.withCredentials = !!this.options.withCredentials),
                                    (l.onload = function (e) {
                                        n._finishedUploading(t, l, e);
                                    }),
                                    (l.ontimeout = function () {
                                        r._handleUploadError(
                                            t,
                                            l,
                                            "Request timedout after ".concat(
                                                r.options.timeout / 1e3,
                                                " seconds"
                                            )
                                        );
                                    }),
                                    (l.onerror = function () {
                                        a._handleUploadError(t, l);
                                    }),
                                    ((null != l.upload ? l.upload : l).onprogress = function (e) {
                                        return o._updateFilesUploadProgress(t, l, e);
                                    });
                                var m = this.options.defaultHeaders
                                    ? {
                                        Accept: "application/json",
                                        "Cache-Control": "no-cache",
                                        "X-Requested-With": "XMLHttpRequest",
                                    }
                                    : {};
                                for (var v in (this.options.binaryBody &&
                                    (m["Content-Type"] = t[0].type),
                                    this.options.headers && e(u)(m, this.options.headers),
                                    m)) {
                                    var y = m[v];
                                    y && l.setRequestHeader(v, y);
                                }
                                if (this.options.binaryBody) {
                                    (s = !0), (c = !1), (d = void 0);
                                    try {
                                        for (
                                            h = t[Symbol.iterator]();
                                            !(s = (x = h.next()).done);
                                            s = !0
                                        ) {
                                            var g = x.value;
                                            this.emit("sending", g, l);
                                        }
                                    } catch (e) {
                                        (c = !0), (d = e);
                                    } finally {
                                        try {
                                            s || null == h.return || h.return();
                                        } finally {
                                            if (c) throw d;
                                        }
                                    }
                                    this.options.uploadMultiple &&
                                        this.emit("sendingmultiple", t, l),
                                        this.submitRequest(l, null, t);
                                } else {
                                    var b = new FormData();
                                    if (this.options.params) {
                                        var k = this.options.params;
                                        for (var w in ("function" == typeof k &&
                                            (k = k.call(
                                                this,
                                                t,
                                                l,
                                                t[0].upload.chunked ? this._getChunk(t[0], l) : null
                                            )),
                                            k)) {
                                            var F = k[w];
                                            if (Array.isArray(F))
                                                for (var E = 0; E < F.length; E++) b.append(w, F[E]);
                                            else b.append(w, F);
                                        }
                                    }
                                    (s = !0), (c = !1), (d = void 0);
                                    try {
                                        var x;
                                        for (
                                            h = t[Symbol.iterator]();
                                            !(s = (x = h.next()).done);
                                            s = !0
                                        ) {
                                            g = x.value;
                                            this.emit("sending", g, l, b);
                                        }
                                    } catch (e) {
                                        (c = !0), (d = e);
                                    } finally {
                                        try {
                                            s || null == h.return || h.return();
                                        } finally {
                                            if (c) throw d;
                                        }
                                    }
                                    this.options.uploadMultiple &&
                                        this.emit("sendingmultiple", t, l, b),
                                        this._addFormElementData(b);
                                    for (E = 0; E < i.length; E++) {
                                        var z = i[E];
                                        b.append(z.name, z.data, z.filename);
                                    }
                                    this.submitRequest(l, b, t);
                                }
                            },
                        },
                        {
                            key: "_transformFiles",
                            value: function (e, t) {
                                for (
                                    var i = this,
                                    n = function (n) {
                                        i.options.transformFile.call(i, e[n], function (i) {
                                            (r[n] = i), ++a === e.length && t(r);
                                        });
                                    },
                                    r = [],
                                    a = 0,
                                    o = 0;
                                    o < e.length;
                                    o++
                                )
                                    n(o);
                            },
                        },
                        {
                            key: "_addFormElementData",
                            value: function (e) {
                                var t = !0,
                                    i = !1,
                                    n = void 0;
                                if ("FORM" === this.element.tagName)
                                    try {
                                        for (
                                            var r = this.element
                                                .querySelectorAll("input, textarea, select, button")
                                            [Symbol.iterator]();
                                            !(t = (s = r.next()).done);
                                            t = !0
                                        ) {
                                            var a = s.value,
                                                o = a.getAttribute("name"),
                                                l = a.getAttribute("type");
                                            if ((l && (l = l.toLowerCase()), null != o))
                                                if (
                                                    "SELECT" === a.tagName &&
                                                    a.hasAttribute("multiple")
                                                ) {
                                                    (t = !0), (i = !1), (n = void 0);
                                                    try {
                                                        var s;
                                                        for (
                                                            r = a.options[Symbol.iterator]();
                                                            !(t = (s = r.next()).done);
                                                            t = !0
                                                        ) {
                                                            var u = s.value;
                                                            u.selected && e.append(o, u.value);
                                                        }
                                                    } catch (e) {
                                                        (i = !0), (n = e);
                                                    } finally {
                                                        try {
                                                            t || null == r.return || r.return();
                                                        } finally {
                                                            if (i) throw n;
                                                        }
                                                    }
                                                } else
                                                    (!l ||
                                                        ("checkbox" !== l && "radio" !== l) ||
                                                        a.checked) &&
                                                        e.append(o, a.value);
                                        }
                                    } catch (e) {
                                        (i = !0), (n = e);
                                    } finally {
                                        try {
                                            t || null == r.return || r.return();
                                        } finally {
                                            if (i) throw n;
                                        }
                                    }
                            },
                        },
                        {
                            key: "_updateFilesUploadProgress",
                            value: function (e, t, i) {
                                var n = !0,
                                    r = !1,
                                    a = void 0;
                                if (e[0].upload.chunked) {
                                    c = e[0];
                                    var o = this._getChunk(c, t);
                                    i
                                        ? ((o.progress = (100 * i.loaded) / i.total),
                                            (o.total = i.total),
                                            (o.bytesSent = i.loaded))
                                        : ((o.progress = 100), (o.bytesSent = o.total)),
                                        (c.upload.progress = 0),
                                        (c.upload.total = 0),
                                        (c.upload.bytesSent = 0);
                                    for (var l = 0; l < c.upload.totalChunkCount; l++)
                                        c.upload.chunks[l] &&
                                            void 0 !== c.upload.chunks[l].progress &&
                                            ((c.upload.progress += c.upload.chunks[l].progress),
                                                (c.upload.total += c.upload.chunks[l].total),
                                                (c.upload.bytesSent += c.upload.chunks[l].bytesSent));
                                    (c.upload.progress =
                                        c.upload.progress / c.upload.totalChunkCount),
                                        this.emit(
                                            "uploadprogress",
                                            c,
                                            c.upload.progress,
                                            c.upload.bytesSent
                                        );
                                } else
                                    try {
                                        for (
                                            var s, u = e[Symbol.iterator]();
                                            !(n = (s = u.next()).done);
                                            n = !0
                                        ) {
                                            var c;
                                            ((c = s.value).upload.total &&
                                                c.upload.bytesSent &&
                                                c.upload.bytesSent == c.upload.total) ||
                                                (i
                                                    ? ((c.upload.progress = (100 * i.loaded) / i.total),
                                                        (c.upload.total = i.total),
                                                        (c.upload.bytesSent = i.loaded))
                                                    : ((c.upload.progress = 100),
                                                        (c.upload.bytesSent = c.upload.total)),
                                                    this.emit(
                                                        "uploadprogress",
                                                        c,
                                                        c.upload.progress,
                                                        c.upload.bytesSent
                                                    ));
                                        }
                                    } catch (e) {
                                        (r = !0), (a = e);
                                    } finally {
                                        try {
                                            n || null == u.return || u.return();
                                        } finally {
                                            if (r) throw a;
                                        }
                                    }
                            },
                        },
                        {
                            key: "_finishedUploading",
                            value: function (e, t, i) {
                                var n;
                                if (e[0].status !== o.CANCELED && 4 === t.readyState) {
                                    if (
                                        "arraybuffer" !== t.responseType &&
                                        "blob" !== t.responseType &&
                                        ((n = t.responseText),
                                            t.getResponseHeader("content-type") &&
                                            ~t
                                                .getResponseHeader("content-type")
                                                .indexOf("application/json"))
                                    )
                                        try {
                                            n = JSON.parse(n);
                                        } catch (e) {
                                            (i = e), (n = "Invalid JSON response from server.");
                                        }
                                    this._updateFilesUploadProgress(e, t),
                                        200 <= t.status && t.status < 300
                                            ? e[0].upload.chunked
                                                ? e[0].upload.finishedChunkUpload(
                                                    this._getChunk(e[0], t),
                                                    n
                                                )
                                                : this._finished(e, n, i)
                                            : this._handleUploadError(e, t, n);
                                }
                            },
                        },
                        {
                            key: "_handleUploadError",
                            value: function (e, t, i) {
                                if (e[0].status !== o.CANCELED) {
                                    if (e[0].upload.chunked && this.options.retryChunks) {
                                        var n = this._getChunk(e[0], t);
                                        if (n.retries++ < this.options.retryChunksLimit)
                                            return void this._uploadData(e, [n.dataBlock]);
                                        console.warn("Retried this chunk too often. Giving up.");
                                    }
                                    this._errorProcessing(
                                        e,
                                        i ||
                                        this.options.dictResponseError.replace(
                                            "{{statusCode}}",
                                            t.status
                                        ),
                                        t
                                    );
                                }
                            },
                        },
                        {
                            key: "submitRequest",
                            value: function (e, t, i) {
                                if (1 == e.readyState)
                                    if (this.options.binaryBody)
                                        if (i[0].upload.chunked) {
                                            var n = this._getChunk(i[0], e);
                                            e.send(n.dataBlock.data);
                                        } else e.send(i[0]);
                                    else e.send(t);
                                else
                                    console.warn(
                                        "Cannot send this request because the XMLHttpRequest.readyState is not OPENED."
                                    );
                            },
                        },
                        {
                            key: "_finished",
                            value: function (e, t, i) {
                                var n = !0,
                                    r = !1,
                                    a = void 0;
                                try {
                                    for (
                                        var l, s = e[Symbol.iterator]();
                                        !(n = (l = s.next()).done);
                                        n = !0
                                    ) {
                                        var u = l.value;
                                        (u.status = o.SUCCESS),
                                            this.emit("success", u, t, i),
                                            this.emit("complete", u);
                                    }
                                } catch (e) {
                                    (r = !0), (a = e);
                                } finally {
                                    try {
                                        n || null == s.return || s.return();
                                    } finally {
                                        if (r) throw a;
                                    }
                                }
                                if (
                                    (this.options.uploadMultiple &&
                                        (this.emit("successmultiple", e, t, i),
                                            this.emit("completemultiple", e)),
                                        this.options.autoProcessQueue)
                                )
                                    return this.processQueue();
                            },
                        },
                        {
                            key: "_errorProcessing",
                            value: function (e, t, i) {
                                var n = !0,
                                    r = !1,
                                    a = void 0;
                                try {
                                    for (
                                        var l, s = e[Symbol.iterator]();
                                        !(n = (l = s.next()).done);
                                        n = !0
                                    ) {
                                        var u = l.value;
                                        (u.status = o.ERROR),
                                            this.emit("error", u, t, i),
                                            this.emit("complete", u);
                                    }
                                } catch (e) {
                                    (r = !0), (a = e);
                                } finally {
                                    try {
                                        n || null == s.return || s.return();
                                    } finally {
                                        if (r) throw a;
                                    }
                                }
                                if (
                                    (this.options.uploadMultiple &&
                                        (this.emit("errormultiple", e, t, i),
                                            this.emit("completemultiple", e)),
                                        this.options.autoProcessQueue)
                                )
                                    return this.processQueue();
                            },
                        },
                    ],
                    [
                        {
                            key: "initClass",
                            value: function () {
                                (this.prototype.Emitter = h),
                                    (this.prototype.events = [
                                        "drop",
                                        "dragstart",
                                        "dragend",
                                        "dragenter",
                                        "dragover",
                                        "dragleave",
                                        "addedfile",
                                        "addedfiles",
                                        "removedfile",
                                        "thumbnail",
                                        "error",
                                        "errormultiple",
                                        "processing",
                                        "processingmultiple",
                                        "uploadprogress",
                                        "totaluploadprogress",
                                        "sending",
                                        "sendingmultiple",
                                        "success",
                                        "successmultiple",
                                        "canceled",
                                        "canceledmultiple",
                                        "complete",
                                        "completemultiple",
                                        "reset",
                                        "maxfilesexceeded",
                                        "maxfilesreached",
                                        "queuecomplete",
                                    ]),
                                    (this.prototype._thumbnailQueue = []),
                                    (this.prototype._processingThumbnail = !1);
                            },
                        },
                        {
                            key: "uuidv4",
                            value: function () {
                                return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(
                                    /[xy]/g,
                                    function (e) {
                                        var t = (16 * Math.random()) | 0;
                                        return ("x" === e ? t : (3 & t) | 8).toString(16);
                                    }
                                );
                            },
                        },
                    ]
                ),
                o
            );
        })(h);
    f.initClass(),
        (f.options = {}),
        (f.optionsForElement = function (e) {
            return e.getAttribute("id") ? f.options[v(e.getAttribute("id"))] : void 0;
        }),
        (f.instances = []),
        (f.forElement = function (e) {
            if (
                ("string" == typeof e && (e = document.querySelector(e)),
                    null == (null != e ? e.dropzone : void 0))
            )
                throw new Error(
                    "No Dropzone found for given element. This is probably because you're trying to access it before Dropzone had the time to initialize. Use the `init` option to setup any additional observers on your Dropzone."
                );
            return e.dropzone;
        }),
        (f.discover = function () {
            var e;
            if (document.querySelectorAll) e = document.querySelectorAll(".dropzone");
            else {
                e = [];
                var t = function (t) {
                    return (function () {
                        var i = [],
                            n = !0,
                            r = !1,
                            a = void 0;
                        try {
                            for (
                                var o, l = t[Symbol.iterator]();
                                !(n = (o = l.next()).done);
                                n = !0
                            ) {
                                var s = o.value;
                                /(^| )dropzone($| )/.test(s.className)
                                    ? i.push(e.push(s))
                                    : i.push(void 0);
                            }
                        } catch (e) {
                            (r = !0), (a = e);
                        } finally {
                            try {
                                n || null == l.return || l.return();
                            } finally {
                                if (r) throw a;
                            }
                        }
                        return i;
                    })();
                };
                t(document.getElementsByTagName("div")),
                    t(document.getElementsByTagName("form"));
            }
            return (function () {
                var t = [],
                    i = !0,
                    n = !1,
                    r = void 0;
                try {
                    for (
                        var a, o = e[Symbol.iterator]();
                        !(i = (a = o.next()).done);
                        i = !0
                    ) {
                        var l = a.value;
                        !1 !== f.optionsForElement(l) ? t.push(new f(l)) : t.push(void 0);
                    }
                } catch (e) {
                    (n = !0), (r = e);
                } finally {
                    try {
                        i || null == o.return || o.return();
                    } finally {
                        if (n) throw r;
                    }
                }
                return t;
            })();
        }),
        (f.blockedBrowsers = [/opera.*(Macintosh|Windows Phone).*version\/12/i]),
        (f.isBrowserSupported = function () {
            var e = !0;
            if (
                window.File &&
                window.FileReader &&
                window.FileList &&
                window.Blob &&
                window.FormData &&
                document.querySelector
            )
                if ("classList" in document.createElement("a")) {
                    void 0 !== f.blacklistedBrowsers &&
                        (f.blockedBrowsers = f.blacklistedBrowsers);
                    var t = !0,
                        i = !1,
                        n = void 0;
                    try {
                        for (
                            var r, a = f.blockedBrowsers[Symbol.iterator]();
                            !(t = (r = a.next()).done);
                            t = !0
                        ) {
                            r.value.test(navigator.userAgent) && (e = !1);
                        }
                    } catch (e) {
                        (i = !0), (n = e);
                    } finally {
                        try {
                            t || null == a.return || a.return();
                        } finally {
                            if (i) throw n;
                        }
                    }
                } else e = !1;
            else e = !1;
            return e;
        }),
        (f.dataURItoBlob = function (e) {
            for (
                var t = atob(e.split(",")[1]),
                i = e.split(",")[0].split(":")[1].split(";")[0],
                n = new ArrayBuffer(t.length),
                r = new Uint8Array(n),
                a = 0,
                o = t.length,
                l = 0 <= o;
                l ? a <= o : a >= o;
                l ? a++ : a--
            )
                r[a] = t.charCodeAt(a);
            return new Blob([n], { type: i });
        });
    var m = function (e, t) {
        return e
            .filter(function (e) {
                return e !== t;
            })
            .map(function (e) {
                return e;
            });
    },
        v = function (e) {
            return e.replace(/[\-_](\w)/g, function (e) {
                return e.charAt(1).toUpperCase();
            });
        };
    (f.createElement = function (e) {
        var t = document.createElement("div");
        return (t.innerHTML = e), t.childNodes[0];
    }),
        (f.elementInside = function (e, t) {
            if (e === t) return !0;
            for (; (e = e.parentNode);) if (e === t) return !0;
            return !1;
        }),
        (f.getElement = function (e, t) {
            var i;
            if (
                ("string" == typeof e
                    ? (i = document.querySelector(e))
                    : null != e.nodeType && (i = e),
                    null == i)
            )
                throw new Error(
                    "Invalid `".concat(
                        t,
                        "` option provided. Please provide a CSS selector or a plain HTML element."
                    )
                );
            return i;
        }),
        (f.getElements = function (e, t) {
            var i, n;
            if (e instanceof Array) {
                n = [];
                try {
                    var r = !0,
                        a = !1,
                        o = void 0;
                    try {
                        for (
                            var l = e[Symbol.iterator]();
                            !(r = (s = l.next()).done);
                            r = !0
                        )
                            (i = s.value), n.push(this.getElement(i, t));
                    } catch (e) {
                        (a = !0), (o = e);
                    } finally {
                        try {
                            r || null == l.return || l.return();
                        } finally {
                            if (a) throw o;
                        }
                    }
                } catch (e) {
                    n = null;
                }
            } else if ("string" == typeof e) {
                n = [];
                (r = !0), (a = !1), (o = void 0);
                try {
                    var s;
                    for (
                        l = document.querySelectorAll(e)[Symbol.iterator]();
                        !(r = (s = l.next()).done);
                        r = !0
                    )
                        (i = s.value), n.push(i);
                } catch (e) {
                    (a = !0), (o = e);
                } finally {
                    try {
                        r || null == l.return || l.return();
                    } finally {
                        if (a) throw o;
                    }
                }
            } else null != e.nodeType && (n = [e]);
            if (null == n || !n.length)
                throw new Error(
                    "Invalid `".concat(
                        t,
                        "` option provided. Please provide a CSS selector, a plain HTML element or a list of those."
                    )
                );
            return n;
        }),
        (f.confirm = function (e, t, i) {
            return window.confirm(e) ? t() : null != i ? i() : void 0;
        }),
        (f.isValidFile = function (e, t) {
            if (!t) return !0;
            t = t.split(",");
            var i = e.type,
                n = i.replace(/\/.*$/, ""),
                r = !0,
                a = !1,
                o = void 0;
            try {
                for (
                    var l, s = t[Symbol.iterator]();
                    !(r = (l = s.next()).done);
                    r = !0
                ) {
                    var u = l.value;
                    if ("." === (u = u.trim()).charAt(0)) {
                        if (
                            -1 !==
                            e.name
                                .toLowerCase()
                                .indexOf(u.toLowerCase(), e.name.length - u.length)
                        )
                            return !0;
                    } else if (/\/\*$/.test(u)) {
                        if (n === u.replace(/\/.*$/, "")) return !0;
                    } else if (i === u) return !0;
                }
            } catch (e) {
                (a = !0), (o = e);
            } finally {
                try {
                    r || null == s.return || s.return();
                } finally {
                    if (a) throw o;
                }
            }
            return !1;
        }),
        "undefined" != typeof jQuery &&
        null !== jQuery &&
        (jQuery.fn.dropzone = function (e) {
            return this.each(function () {
                return new f(this, e);
            });
        }),
        (f.ADDED = "added"),
        (f.QUEUED = "queued"),
        (f.ACCEPTED = f.QUEUED),
        (f.UPLOADING = "uploading"),
        (f.PROCESSING = f.UPLOADING),
        (f.CANCELED = "canceled"),
        (f.ERROR = "error"),
        (f.SUCCESS = "success");
    var y = function (e, t, i, n, r, a, o, l, s, u) {
        var c = (function (e) {
            e.naturalWidth;
            var t = e.naturalHeight,
                i = document.createElement("canvas");
            (i.width = 1), (i.height = t);
            var n = i.getContext("2d");
            n.drawImage(e, 0, 0);
            for (
                var r = n.getImageData(1, 0, 1, t).data, a = 0, o = t, l = t;
                l > a;

            )
                0 === r[4 * (l - 1) + 3] ? (o = l) : (a = l), (l = (o + a) >> 1);
            var s = l / t;
            return 0 === s ? 1 : s;
        })(t);
        return e.drawImage(t, i, n, r, a, o, l, s, u / c);
    },
        g = (function () {
            "use strict";
            function e() {
                i(this, e);
            }
            return (
                r(e, null, [
                    {
                        key: "initClass",
                        value: function () {
                            this.KEY_STR =
                                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
                        },
                    },
                    {
                        key: "encode64",
                        value: function (e) {
                            for (
                                var t = "",
                                i = void 0,
                                n = void 0,
                                r = "",
                                a = void 0,
                                o = void 0,
                                l = void 0,
                                s = "",
                                u = 0;
                                (a = (i = e[u++]) >> 2),
                                (o = ((3 & i) << 4) | ((n = e[u++]) >> 4)),
                                (l = ((15 & n) << 2) | ((r = e[u++]) >> 6)),
                                (s = 63 & r),
                                isNaN(n) ? (l = s = 64) : isNaN(r) && (s = 64),
                                (t =
                                    t +
                                    this.KEY_STR.charAt(a) +
                                    this.KEY_STR.charAt(o) +
                                    this.KEY_STR.charAt(l) +
                                    this.KEY_STR.charAt(s)),
                                (i = n = r = ""),
                                (a = o = l = s = ""),
                                u < e.length;

                            );
                            return t;
                        },
                    },
                    {
                        key: "restore",
                        value: function (e, t) {
                            if (!e.match("data:image/jpeg;base64,")) return t;
                            var i = this.decode64(e.replace("data:image/jpeg;base64,", "")),
                                n = this.slice2Segments(i),
                                r = this.exifManipulation(t, n);
                            return "data:image/jpeg;base64,".concat(this.encode64(r));
                        },
                    },
                    {
                        key: "exifManipulation",
                        value: function (e, t) {
                            var i = this.getExifArray(t),
                                n = this.insertExif(e, i);
                            return new Uint8Array(n);
                        },
                    },
                    {
                        key: "getExifArray",
                        value: function (e) {
                            for (var t = void 0, i = 0; i < e.length;) {
                                if ((255 === (t = e[i])[0]) & (225 === t[1])) return t;
                                i++;
                            }
                            return [];
                        },
                    },
                    {
                        key: "insertExif",
                        value: function (e, t) {
                            var i = e.replace("data:image/jpeg;base64,", ""),
                                n = this.decode64(i),
                                r = n.indexOf(255, 3),
                                a = n.slice(0, r),
                                o = n.slice(r),
                                l = a;
                            return (l = (l = l.concat(t)).concat(o));
                        },
                    },
                    {
                        key: "slice2Segments",
                        value: function (e) {
                            for (var t = 0, i = []; ;) {
                                if ((255 === e[t]) & (218 === e[t + 1])) break;
                                if ((255 === e[t]) & (216 === e[t + 1])) t += 2;
                                else {
                                    var n = t + (256 * e[t + 2] + e[t + 3]) + 2,
                                        r = e.slice(t, n);
                                    i.push(r), (t = n);
                                }
                                if (t > e.length) break;
                            }
                            return i;
                        },
                    },
                    {
                        key: "decode64",
                        value: function (e) {
                            var t = void 0,
                                i = void 0,
                                n = "",
                                r = void 0,
                                a = void 0,
                                o = "",
                                l = 0,
                                s = [];
                            for (
                                /[^A-Za-z0-9\+\/\=]/g.exec(e) &&
                                console.warn(
                                    "There were invalid base64 characters in the input text.\nValid base64 characters are A-Z, a-z, 0-9, '+', '/',and '='\nExpect errors in decoding."
                                ),
                                e = e.replace(/[^A-Za-z0-9\+\/\=]/g, "");
                                (t =
                                    (this.KEY_STR.indexOf(e.charAt(l++)) << 2) |
                                    ((r = this.KEY_STR.indexOf(e.charAt(l++))) >> 4)),
                                (i =
                                    ((15 & r) << 4) |
                                    ((a = this.KEY_STR.indexOf(e.charAt(l++))) >> 2)),
                                (n =
                                    ((3 & a) << 6) | (o = this.KEY_STR.indexOf(e.charAt(l++)))),
                                s.push(t),
                                64 !== a && s.push(i),
                                64 !== o && s.push(n),
                                (t = i = n = ""),
                                (r = a = o = ""),
                                l < e.length;

                            );
                            return s;
                        },
                    },
                ]),
                e
            );
        })();
    g.initClass();
    window.Dropzone = f;
})();
//# sourceMappingURL=dropzone-min.js.map
