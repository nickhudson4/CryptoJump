(this.webpackJsonpweb3gl=this.webpackJsonpweb3gl||[]).push([[11],{1305:function(r,e,n){"use strict";(function(e){var t=n(219),f=n(1306),i=n(1307),o=function(r){return 32===r.length&&t.privateKeyVerify(Uint8Array.from(r))};r.exports={privateKeyVerify:o,privateKeyExport:function(r,e){if(32!==r.length)throw new RangeError("private key length is invalid");var n=f.privateKeyExport(r,e);return i.privateKeyExport(r,n,e)},privateKeyImport:function(r){if(null!==(r=i.privateKeyImport(r))&&32===r.length&&o(r))return r;throw new Error("couldn't import from DER format")},privateKeyNegate:function(r){return e.from(t.privateKeyNegate(Uint8Array.from(r)))},privateKeyModInverse:function(r){if(32!==r.length)throw new Error("private key length is invalid");return e.from(f.privateKeyModInverse(Uint8Array.from(r)))},privateKeyTweakAdd:function(r,n){return e.from(t.privateKeyTweakAdd(Uint8Array.from(r),n))},privateKeyTweakMul:function(r,n){return e.from(t.privateKeyTweakMul(Uint8Array.from(r),Uint8Array.from(n)))},publicKeyCreate:function(r,n){return e.from(t.publicKeyCreate(Uint8Array.from(r),n))},publicKeyConvert:function(r,n){return e.from(t.publicKeyConvert(Uint8Array.from(r),n))},publicKeyVerify:function(r){return(33===r.length||65===r.length)&&t.publicKeyVerify(Uint8Array.from(r))},publicKeyTweakAdd:function(r,n,f){return e.from(t.publicKeyTweakAdd(Uint8Array.from(r),Uint8Array.from(n),f))},publicKeyTweakMul:function(r,n,f){return e.from(t.publicKeyTweakMul(Uint8Array.from(r),Uint8Array.from(n),f))},publicKeyCombine:function(r,n){var f=[];return r.forEach((function(r){f.push(Uint8Array.from(r))})),e.from(t.publicKeyCombine(f,n))},signatureNormalize:function(r){return e.from(t.signatureNormalize(Uint8Array.from(r)))},signatureExport:function(r){return e.from(t.signatureExport(Uint8Array.from(r)))},signatureImport:function(r){return e.from(t.signatureImport(Uint8Array.from(r)))},signatureImportLax:function(r){if(0===r.length)throw new RangeError("signature length is invalid");var e=i.signatureImportLax(r);if(null===e)throw new Error("couldn't parse DER signature");return f.signatureImport(e)},sign:function(r,n,f){if(null===f)throw new TypeError("options should be an Object");var i=void 0;if(f){if(i={},null===f.data)throw new TypeError("options.data should be a Buffer");if(f.data){if(32!==f.data.length)throw new RangeError("options.data length is invalid");i.data=new Uint8Array(f.data)}if(null===f.noncefn)throw new TypeError("options.noncefn should be a Function");f.noncefn&&(i.noncefn=function(r,n,t,i,o){var a=null!=t?e.from(t):null,u=null!=i?e.from(i):null,c=e.from("");return f.noncefn&&(c=f.noncefn(e.from(r),e.from(n),a,u,o)),Uint8Array.from(c)})}var o=t.ecdsaSign(Uint8Array.from(r),Uint8Array.from(n),i);return{signature:e.from(o.signature),recovery:o.recid}},verify:function(r,e,n){return t.ecdsaVerify(Uint8Array.from(e),Uint8Array.from(r),n)},recover:function(r,n,f,i){return e.from(t.ecdsaRecover(Uint8Array.from(n),f,Uint8Array.from(r),i))},ecdh:function(r,n){return e.from(t.ecdh(Uint8Array.from(r),Uint8Array.from(n),{}))},ecdhUnsafe:function(r,n,t){if(33!==r.length&&65!==r.length)throw new RangeError("public key length is invalid");if(32!==n.length)throw new RangeError("private key length is invalid");return e.from(f.ecdhUnsafe(Uint8Array.from(r),Uint8Array.from(n),t))}}}).call(this,n(5).Buffer)},1306:function(r,e,n){"use strict";(function(r){var t=n(8),f=new(0,n(44).ec)("secp256k1"),i=f.curve;e.privateKeyExport=function(r,e){var n=new t(r);if(n.ucmp(i.n)>=0)throw new Error("couldn't export to DER format");var a=f.g.mul(n);return o(a.getX(),a.getY(),e)},e.privateKeyModInverse=function(e){var n=new t(e);if(n.ucmp(i.n)>=0||n.isZero())throw new Error("private key range is invalid");return n.invm(i.n).toArrayLike(r,"be",32)},e.signatureImport=function(e){var n=new t(e.r);n.ucmp(i.n)>=0&&(n=new t(0));var f=new t(e.s);return f.ucmp(i.n)>=0&&(f=new t(0)),r.concat([n.toArrayLike(r,"be",32),f.toArrayLike(r,"be",32)])},e.ecdhUnsafe=function(r,e,n){var a=f.keyFromPublic(r),u=new t(e);if(u.ucmp(i.n)>=0||u.isZero())throw new Error("scalar was invalid (zero or overflow)");var c=a.pub.mul(u);return o(c.getX(),c.getY(),n)};var o=function(e,n,t){var f=void 0;return t?((f=r.alloc(33))[0]=n.isOdd()?3:2,e.toArrayLike(r,"be",32).copy(f,1)):((f=r.alloc(65))[0]=4,e.toArrayLike(r,"be",32).copy(f,1),n.toArrayLike(r,"be",32).copy(f,33)),f}}).call(this,n(5).Buffer)},1307:function(r,e,n){"use strict";(function(r){var n=r.from([48,129,211,2,1,1,4,32,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,160,129,133,48,129,130,2,1,1,48,44,6,7,42,134,72,206,61,1,1,2,33,0,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,254,255,255,252,47,48,6,4,1,0,4,1,7,4,33,2,121,190,102,126,249,220,187,172,85,160,98,149,206,135,11,7,2,155,252,219,45,206,40,217,89,242,129,91,22,248,23,152,2,33,0,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,254,186,174,220,230,175,72,160,59,191,210,94,140,208,54,65,65,2,1,1,161,36,3,34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]),t=r.from([48,130,1,19,2,1,1,4,32,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,160,129,165,48,129,162,2,1,1,48,44,6,7,42,134,72,206,61,1,1,2,33,0,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,254,255,255,252,47,48,6,4,1,0,4,1,7,4,65,4,121,190,102,126,249,220,187,172,85,160,98,149,206,135,11,7,2,155,252,219,45,206,40,217,89,242,129,91,22,248,23,152,72,58,218,119,38,163,196,101,93,164,251,252,14,17,8,168,253,23,180,72,166,133,84,25,156,71,208,143,251,16,212,184,2,33,0,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,254,186,174,220,230,175,72,160,59,191,210,94,140,208,54,65,65,2,1,1,161,68,3,66,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]);e.privateKeyExport=function(e,f,i){var o=r.from(i?n:t);return e.copy(o,i?8:9),f.copy(o,i?181:214),o},e.privateKeyImport=function(r){var e=r.length,n=0;if(e<n+1||48!==r[n])return null;if(e<(n+=1)+1||!(128&r[n]))return null;var t=127&r[n];if(t<1||t>2)return null;if(e<(n+=1)+t)return null;var f=r[n+t-1]|(t>1?r[n+t-2]<<8:0);return e<(n+=t)+f||e<n+3||2!==r[n]||1!==r[n+1]||1!==r[n+2]||e<(n+=3)+2||4!==r[n]||r[n+1]>32||e<n+2+r[n+1]?null:r.slice(n+2,n+2+r[n+1])},e.signatureImportLax=function(e){var n=r.alloc(32,0),t=r.alloc(32,0),f=e.length,i=0;if(48!==e[i++])return null;var o=e[i++];if(128&o&&(i+=o-128)>f)return null;if(2!==e[i++])return null;var a=e[i++];if(128&a){if(i+(o=a-128)>f)return null;for(;o>0&&0===e[i];i+=1,o-=1);for(a=0;o>0;i+=1,o-=1)a=(a<<8)+e[i]}if(a>f-i)return null;var u=i;if(i+=a,2!==e[i++])return null;var c=e[i++];if(128&c){if(i+(o=c-128)>f)return null;for(;o>0&&0===e[i];i+=1,o-=1);for(c=0;o>0;i+=1,o-=1)c=(c<<8)+e[i]}if(c>f-i)return null;var l=i;for(i+=c;a>0&&0===e[u];a-=1,u+=1);if(a>32)return null;var s=e.slice(u,u+a);for(s.copy(n,32-s.length);c>0&&0===e[l];c-=1,l+=1);if(c>32)return null;var d=e.slice(l,l+c);return d.copy(t,32-d.length),{r:n,s:t}}}).call(this,n(5).Buffer)},593:function(r,e,n){"use strict";var t="function"===typeof Symbol&&"symbol"===typeof Symbol.iterator?function(r){return typeof r}:function(r){return r&&"function"===typeof Symbol&&r.constructor===Symbol&&r!==Symbol.prototype?"symbol":typeof r},f=n(222),i=f.keccak224,o=f.keccak384,a=f.keccak256,u=f.keccak512,c=n(1305),l=n(116),s=n(80),d=n(8),p=n(41),y=n(11).Buffer;Object.assign(e,n(52)),e.MAX_INTEGER=new d("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff",16),e.TWO_POW256=new d("10000000000000000000000000000000000000000000000000000000000000000",16),e.KECCAK256_NULL_S="c5d2460186f7233c927e7db2dcc703c0e500b653ca82273b7bfad8045d85a470",e.SHA3_NULL_S=e.KECCAK256_NULL_S,e.KECCAK256_NULL=y.from(e.KECCAK256_NULL_S,"hex"),e.SHA3_NULL=e.KECCAK256_NULL,e.KECCAK256_RLP_ARRAY_S="1dcc4de8dec75d7aab85b567b6ccd41ad312451b948a7413f0a142fd40d49347",e.SHA3_RLP_ARRAY_S=e.KECCAK256_RLP_ARRAY_S,e.KECCAK256_RLP_ARRAY=y.from(e.KECCAK256_RLP_ARRAY_S,"hex"),e.SHA3_RLP_ARRAY=e.KECCAK256_RLP_ARRAY,e.KECCAK256_RLP_S="56e81f171bcc55a6ff8345e692c0f86e5b48e01b996cadc001622fb5e363b421",e.SHA3_RLP_S=e.KECCAK256_RLP_S,e.KECCAK256_RLP=y.from(e.KECCAK256_RLP_S,"hex"),e.SHA3_RLP=e.KECCAK256_RLP,e.BN=d,e.rlp=s,e.secp256k1=c,e.zeros=function(r){return y.allocUnsafe(r).fill(0)},e.zeroAddress=function(){var r=e.zeros(20);return e.bufferToHex(r)},e.setLengthLeft=e.setLength=function(r,n,t){var f=e.zeros(n);return r=e.toBuffer(r),t?r.length<n?(r.copy(f),f):r.slice(0,n):r.length<n?(r.copy(f,n-r.length),f):r.slice(-n)},e.setLengthRight=function(r,n){return e.setLength(r,n,!0)},e.unpad=e.stripZeros=function(r){for(var n=(r=e.stripHexPrefix(r))[0];r.length>0&&"0"===n.toString();)n=(r=r.slice(1))[0];return r},e.toBuffer=function(r){if(!y.isBuffer(r))if(Array.isArray(r))r=y.from(r);else if("string"===typeof r)r=e.isHexString(r)?y.from(e.padToEven(e.stripHexPrefix(r)),"hex"):y.from(r);else if("number"===typeof r)r=e.intToBuffer(r);else if(null===r||void 0===r)r=y.allocUnsafe(0);else if(d.isBN(r))r=r.toArrayLike(y);else{if(!r.toArray)throw new Error("invalid type");r=y.from(r.toArray())}return r},e.bufferToInt=function(r){return new d(e.toBuffer(r)).toNumber()},e.bufferToHex=function(r){return"0x"+(r=e.toBuffer(r)).toString("hex")},e.fromSigned=function(r){return new d(r).fromTwos(256)},e.toUnsigned=function(r){return y.from(r.toTwos(256).toArray())},e.keccak=function(r,n){switch(r=e.toBuffer(r),n||(n=256),n){case 224:return i(r);case 256:return a(r);case 384:return o(r);case 512:return u(r);default:throw new Error("Invald algorithm: keccak"+n)}},e.keccak256=function(r){return e.keccak(r)},e.sha3=e.keccak,e.sha256=function(r){return r=e.toBuffer(r),p("sha256").update(r).digest()},e.ripemd160=function(r,n){r=e.toBuffer(r);var t=p("rmd160").update(r).digest();return!0===n?e.setLength(t,32):t},e.rlphash=function(r){return e.keccak(s.encode(r))},e.isValidPrivate=function(r){return c.privateKeyVerify(r)},e.isValidPublic=function(r,e){return 64===r.length?c.publicKeyVerify(y.concat([y.from([4]),r])):!!e&&c.publicKeyVerify(r)},e.pubToAddress=e.publicToAddress=function(r,n){return r=e.toBuffer(r),n&&64!==r.length&&(r=c.publicKeyConvert(r,!1).slice(1)),l(64===r.length),e.keccak(r).slice(-20)};var h=e.privateToPublic=function(r){return r=e.toBuffer(r),c.publicKeyCreate(r,!1).slice(1)};e.importPublic=function(r){return 64!==(r=e.toBuffer(r)).length&&(r=c.publicKeyConvert(r,!1).slice(1)),r},e.ecsign=function(r,e){var n=c.sign(r,e),t={};return t.r=n.signature.slice(0,32),t.s=n.signature.slice(32,64),t.v=n.recovery+27,t},e.hashPersonalMessage=function(r){var n=e.toBuffer("\x19Ethereum Signed Message:\n"+r.length.toString());return e.keccak(y.concat([n,r]))},e.ecrecover=function(r,n,t,f){var i=y.concat([e.setLength(t,32),e.setLength(f,32)],64),o=n-27;if(0!==o&&1!==o)throw new Error("Invalid signature v value");var a=c.recover(r,i,o);return c.publicKeyConvert(a,!1).slice(1)},e.toRpcSig=function(r,n,t){if(27!==r&&28!==r)throw new Error("Invalid recovery id");return e.bufferToHex(y.concat([e.setLengthLeft(n,32),e.setLengthLeft(t,32),e.toBuffer(r-27)]))},e.fromRpcSig=function(r){if(65!==(r=e.toBuffer(r)).length)throw new Error("Invalid signature length");var n=r[64];return n<27&&(n+=27),{v:n,r:r.slice(0,32),s:r.slice(32,64)}},e.privateToAddress=function(r){return e.publicToAddress(h(r))},e.isValidAddress=function(r){return/^0x[0-9a-fA-F]{40}$/.test(r)},e.isZeroAddress=function(r){return e.zeroAddress()===e.addHexPrefix(r)},e.toChecksumAddress=function(r){r=e.stripHexPrefix(r).toLowerCase();for(var n=e.keccak(r).toString("hex"),t="0x",f=0;f<r.length;f++)parseInt(n[f],16)>=8?t+=r[f].toUpperCase():t+=r[f];return t},e.isValidChecksumAddress=function(r){return e.isValidAddress(r)&&e.toChecksumAddress(r)===r},e.generateAddress=function(r,n){return r=e.toBuffer(r),n=(n=new d(n)).isZero()?null:y.from(n.toArray()),e.rlphash([r,n]).slice(-20)},e.isPrecompiled=function(r){var n=e.unpad(r);return 1===n.length&&n[0]>=1&&n[0]<=8},e.addHexPrefix=function(r){return"string"!==typeof r||e.isHexPrefixed(r)?r:"0x"+r},e.isValidSignature=function(r,e,n,t){var f=new d("7fffffffffffffffffffffffffffffff5d576e7357a4501ddfe92f46681b20a0",16),i=new d("fffffffffffffffffffffffffffffffebaaedce6af48a03bbfd25e8cd0364141",16);return 32===e.length&&32===n.length&&((27===r||28===r)&&(e=new d(e),n=new d(n),!(e.isZero()||e.gt(i)||n.isZero()||n.gt(i))&&(!1!==t||1!==new d(n).cmp(f))))},e.baToJSON=function(r){if(y.isBuffer(r))return"0x"+r.toString("hex");if(r instanceof Array){for(var n=[],t=0;t<r.length;t++)n.push(e.baToJSON(r[t]));return n}},e.defineProperties=function(r,n,f){if(r.raw=[],r._fields=[],r.toJSON=function(n){if(n){var t={};return r._fields.forEach((function(e){t[e]="0x"+r[e].toString("hex")})),t}return e.baToJSON(this.raw)},r.serialize=function(){return s.encode(r.raw)},n.forEach((function(n,t){function f(){return r.raw[t]}function i(f){"00"!==(f=e.toBuffer(f)).toString("hex")||n.allowZero||(f=y.allocUnsafe(0)),n.allowLess&&n.length?(f=e.stripZeros(f),l(n.length>=f.length,"The field "+n.name+" must not have more "+n.length+" bytes")):n.allowZero&&0===f.length||!n.length||l(n.length===f.length,"The field "+n.name+" must have byte length of "+n.length),r.raw[t]=f}r._fields.push(n.name),Object.defineProperty(r,n.name,{enumerable:!0,configurable:!0,get:f,set:i}),n.default&&(r[n.name]=n.default),n.alias&&Object.defineProperty(r,n.alias,{enumerable:!1,configurable:!0,set:i,get:f})})),f)if("string"===typeof f&&(f=y.from(e.stripHexPrefix(f),"hex")),y.isBuffer(f)&&(f=s.decode(f)),Array.isArray(f)){if(f.length>r._fields.length)throw new Error("wrong number of fields in data");f.forEach((function(n,t){r[r._fields[t]]=e.toBuffer(n)}))}else{if("object"!==("undefined"===typeof f?"undefined":t(f)))throw new Error("invalid data");var i=Object.keys(f);n.forEach((function(e){-1!==i.indexOf(e.name)&&(r[e.name]=f[e.name]),-1!==i.indexOf(e.alias)&&(r[e.alias]=f[e.alias])}))}}}}]);
