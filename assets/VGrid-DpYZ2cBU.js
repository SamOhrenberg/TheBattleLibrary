import{ak as Z,h as T,al as Ke,a6 as Je,m as A,a5 as Qe,am as Ze,J as _e,p as k,l as u,an as O,ao as pe,ap as fe,aq as et,ar as tt,as as nt,a8 as $,a as f,F as at,b as ee,g as G,G as q,H,t as w,i as D,at as st,N as xe,n as se,L as lt,z as le,au as it,ad as we,av as Be,a9 as ot,af as rt,v as ie,ac as ut,aw as ct,C as dt,D as S,a0 as te,q as oe,ax as vt,ay as ft,az as mt,s as gt,S as ht,aA as bt,R as yt,I as Ie,K as me,aB as Ct,a4 as kt,aC as St,aD as ge,y as _t,aE as pt,aF as he,j as xt,k as wt,A as Bt}from"./index-DzLv7Ehd.js";const It=["top","bottom"],Vt=["start","end","left","right"];function Lt(e,t){let[a,n]=e.split(" ");return n||(n=Z(It,a)?"start":Z(Vt,a)?"top":"center"),{side:be(a,t),align:be(n,t)}}function be(e,t){return e==="start"?t?"right":"left":e==="end"?t?"left":"right":e}function vn(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:"div",a=arguments.length>2?arguments[2]:void 0;return T()({name:a??Ke(Je(e.replace(/__/g,"-"))),props:{tag:{type:String,default:t},...A()},setup(n,s){let{slots:l}=s;return()=>{var o;return Qe(n.tag,{class:[e,n.class],style:n.style},(o=l.default)==null?void 0:o.call(l))}}})}const Pt=k({defaults:Object,disabled:Boolean,reset:[Number,String],root:[Boolean,String],scoped:Boolean},"VDefaultsProvider"),K=T(!1)({name:"VDefaultsProvider",props:Pt(),setup(e,t){let{slots:a}=t;const{defaults:n,disabled:s,reset:l,root:o,scoped:c}=Ze(e);return _e(n,{reset:l,root:o,scoped:c,disabled:s}),()=>{var d;return(d=a.default)==null?void 0:d.call(a)}}});function re(e){return pe(()=>{const t=[],a={};if(e.value.background)if(fe(e.value.background)){if(a.backgroundColor=e.value.background,!e.value.text&&et(e.value.background)){const n=tt(e.value.background);if(n.a==null||n.a===1){const s=nt(n);a.color=s,a.caretColor=s}}}else t.push(`bg-${e.value.background}`);return e.value.text&&(fe(e.value.text)?(a.color=e.value.text,a.caretColor=e.value.text):t.push(`text-${e.value.text}`)),{colorClasses:t,colorStyles:a}})}function j(e,t){const a=u(()=>({text:O(e)?e.value:t?e[t]:null})),{colorClasses:n,colorStyles:s}=re(a);return{textColorClasses:n,textColorStyles:s}}function J(e,t){const a=u(()=>({background:O(e)?e.value:t?e[t]:null})),{colorClasses:n,colorStyles:s}=re(a);return{backgroundColorClasses:n,backgroundColorStyles:s}}const ue=k({rounded:{type:[Boolean,Number,String],default:void 0},tile:Boolean},"rounded");function ce(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:$();return{roundedClasses:u(()=>{const n=O(e)?e.value:e.rounded,s=O(e)?e.value:e.tile,l=[];if(n===!0||n==="")l.push(`${t}--rounded`);else if(typeof n=="string"||n===0)for(const o of String(n).split(" "))l.push(`rounded-${o}`);else(s||n===!1)&&l.push("rounded-0");return l})}}const Ve=k({border:[Boolean,Number,String]},"border");function Le(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:$();return{borderClasses:u(()=>{const n=O(e)?e.value:e.border,s=[];if(n===!0||n==="")s.push(`${t}--border`);else if(typeof n=="string"||n===0)for(const l of String(n).split(" "))s.push(`border-${l}`);return s})}}const Pe=k({elevation:{type:[Number,String],validator(e){const t=parseInt(e);return!isNaN(t)&&t>=0&&t<=24}}},"elevation");function Ee(e){return{elevationClasses:u(()=>{const a=O(e)?e.value:e.elevation,n=[];return a==null||n.push(`elevation-${a}`),n})}}const Et=[null,"default","comfortable","compact"],Te=k({density:{type:String,default:"default",validator:e=>Et.includes(e)}},"density");function $e(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:$();return{densityClasses:u(()=>`${t}--density-${e.density}`)}}const Tt=["elevated","flat","tonal","outlined","text","plain"];function $t(e,t){return f(at,null,[e&&f("span",{key:"overlay",class:`${t}__overlay`},null),f("span",{key:"underlay",class:`${t}__underlay`},null)])}const Ne=k({color:String,variant:{type:String,default:"elevated",validator:e=>Tt.includes(e)}},"variant");function Nt(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:$();const a=u(()=>{const{variant:l}=ee(e);return`${t}--variant-${l}`}),{colorClasses:n,colorStyles:s}=re(u(()=>{const{variant:l,color:o}=ee(e);return{[["elevated","flat"].includes(l)?"background":"text"]:o}}));return{colorClasses:n,colorStyles:s,variantClasses:a}}const Re=k({baseColor:String,divided:Boolean,...Ve(),...A(),...Te(),...Pe(),...ue(),...G(),...q(),...Ne()},"VBtnGroup"),ye=T()({name:"VBtnGroup",props:Re(),setup(e,t){let{slots:a}=t;const{themeClasses:n}=H(e),{densityClasses:s}=$e(e),{borderClasses:l}=Le(e),{elevationClasses:o}=Ee(e),{roundedClasses:c}=ce(e);_e({VBtn:{height:"auto",baseColor:w(e,"baseColor"),color:w(e,"color"),density:w(e,"density"),flat:!0,variant:w(e,"variant")}}),D(()=>f(e.tag,{class:["v-btn-group",{"v-btn-group--divided":e.divided},n.value,l.value,s.value,o.value,c.value,e.class],style:e.style},a))}}),Rt=k({modelValue:{type:null,default:void 0},multiple:Boolean,mandatory:[Boolean,String],max:Number,selectedClass:String,disabled:Boolean},"group"),zt=k({value:null,disabled:Boolean,selectedClass:String},"group-item");function Ot(e,t){let a=arguments.length>2&&arguments[2]!==void 0?arguments[2]:!0;const n=se("useGroupItem");if(!n)throw new Error("[Vuetify] useGroupItem composable must be used inside a component setup function");const s=ot();we(Symbol.for(`${t.description}:id`),s);const l=rt(t,null);if(!l){if(!a)return l;throw new Error(`[Vuetify] Could not find useGroup injection with symbol ${t.description}`)}const o=w(e,"value"),c=u(()=>!!(l.disabled.value||e.disabled));l.register({id:s,value:o,disabled:c},n),le(()=>{l.unregister(s)});const d=u(()=>l.isSelected(s)),b=u(()=>l.items.value[0].id===s),y=u(()=>l.items.value[l.items.value.length-1].id===s),m=u(()=>d.value&&[l.selectedClass.value,e.selectedClass]);return ie(d,i=>{n.emit("group:selected",{value:i})},{flush:"sync"}),{id:s,isSelected:d,isFirst:b,isLast:y,toggle:()=>l.select(s,!d.value),select:i=>l.select(s,i),selectedClass:m,value:o,disabled:c,group:l}}function At(e,t){let a=!1;const n=st([]),s=xe(e,"modelValue",[],i=>i==null?[]:ze(n,ut(i)),i=>{const v=Ft(n,i);return e.multiple?v:v[0]}),l=se("useGroup");function o(i,v){const g=i,r=Symbol.for(`${t.description}:id`),C=ct(r,l==null?void 0:l.vnode).indexOf(v);ee(g.value)==null&&(g.value=C,g.useIndexAsValue=!0),C>-1?n.splice(C,0,g):n.push(g)}function c(i){if(a)return;d();const v=n.findIndex(g=>g.id===i);n.splice(v,1)}function d(){const i=n.find(v=>!v.disabled);i&&e.mandatory==="force"&&!s.value.length&&(s.value=[i.id])}lt(()=>{d()}),le(()=>{a=!0}),it(()=>{for(let i=0;i<n.length;i++)n[i].useIndexAsValue&&(n[i].value=i)});function b(i,v){const g=n.find(r=>r.id===i);if(!(v&&(g!=null&&g.disabled)))if(e.multiple){const r=s.value.slice(),h=r.findIndex(L=>L===i),C=~h;if(v=v??!C,C&&e.mandatory&&r.length<=1||!C&&e.max!=null&&r.length+1>e.max)return;h<0&&v?r.push(i):h>=0&&!v&&r.splice(h,1),s.value=r}else{const r=s.value.includes(i);if(e.mandatory&&r)return;s.value=v??!r?[i]:[]}}function y(i){if(e.multiple,s.value.length){const v=s.value[0],g=n.findIndex(C=>C.id===v);let r=(g+i)%n.length,h=n[r];for(;h.disabled&&r!==g;)r=(r+i)%n.length,h=n[r];if(h.disabled)return;s.value=[n[r].id]}else{const v=n.find(g=>!g.disabled);v&&(s.value=[v.id])}}const m={register:o,unregister:c,selected:s,select:b,disabled:w(e,"disabled"),prev:()=>y(n.length-1),next:()=>y(1),isSelected:i=>s.value.includes(i),selectedClass:u(()=>e.selectedClass),items:u(()=>n),getItemIndex:i=>Dt(n,i)};return we(t,m),m}function Dt(e,t){const a=ze(e,[t]);return a.length?e.findIndex(n=>n.id===a[0]):-1}function ze(e,t){const a=[];return t.forEach(n=>{const s=e.find(o=>Be(n,o.value)),l=e[n];(s==null?void 0:s.value)!=null?a.push(s.id):l!=null&&a.push(l.id)}),a}function Ft(e,t){const a=[];return t.forEach(n=>{const s=e.findIndex(l=>l.id===n);if(~s){const l=e[s];a.push(l.value!=null?l.value:s)}}),a}const Oe=Symbol.for("vuetify:v-btn-toggle"),Mt=k({...Re(),...Rt()},"VBtnToggle");T()({name:"VBtnToggle",props:Mt(),emits:{"update:modelValue":e=>!0},setup(e,t){let{slots:a}=t;const{isSelected:n,next:s,prev:l,select:o,selected:c}=At(e,Oe);return D(()=>{const d=ye.filterProps(e);return f(ye,dt({class:["v-btn-toggle",e.class]},d,{style:e.style}),{default:()=>{var b;return[(b=a.default)==null?void 0:b.call(a,{isSelected:n,next:s,prev:l,select:o,selected:c})]}})}),{next:s,prev:l,select:o}}});const Gt=["x-small","small","default","large","x-large"],de=k({size:{type:[String,Number],default:"default"}},"size");function ve(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:$();return pe(()=>{let a,n;return Z(Gt,e.size)?a=`${t}--size-${e.size}`:e.size&&(n={width:S(e.size),height:S(e.size)}),{sizeClasses:a,sizeStyles:n}})}const qt=k({color:String,disabled:Boolean,start:Boolean,end:Boolean,icon:te,...A(),...de(),...G({tag:"i"}),...q()},"VIcon"),Q=T()({name:"VIcon",props:qt(),setup(e,t){let{attrs:a,slots:n}=t;const s=oe(),{themeClasses:l}=H(e),{iconData:o}=vt(u(()=>s.value||e.icon)),{sizeClasses:c}=ve(e),{textColorClasses:d,textColorStyles:b}=j(w(e,"color"));return D(()=>{var i,v;const y=(i=n.default)==null?void 0:i.call(n);y&&(s.value=(v=ft(y).filter(g=>g.type===mt&&g.children&&typeof g.children=="string")[0])==null?void 0:v.children);const m=!!(a.onClick||a.onClickOnce);return f(o.value.component,{tag:e.tag,icon:o.value.icon,class:["v-icon","notranslate",l.value,c.value,d.value,{"v-icon--clickable":m,"v-icon--disabled":e.disabled,"v-icon--start":e.start,"v-icon--end":e.end},e.class],style:[c.value?void 0:{fontSize:S(e.size),height:S(e.size),width:S(e.size)},b.value,e.style],role:m?"button":void 0,"aria-hidden":!m,tabindex:m?e.disabled?-1:0:void 0},{default:()=>[y]})}),{}}});function Ae(e,t){const a=oe(),n=gt(!1);if(ht){const s=new IntersectionObserver(l=>{n.value=!!l.find(o=>o.isIntersecting)},t);le(()=>{s.disconnect()}),ie(a,(l,o)=>{o&&(s.unobserve(o),n.value=!1),l&&s.observe(l)},{flush:"post"})}return{intersectionRef:a,isIntersecting:n}}const Ht=k({bgColor:String,color:String,indeterminate:[Boolean,String],modelValue:{type:[Number,String],default:0},rotate:{type:[Number,String],default:0},width:{type:[Number,String],default:4},...A(),...de(),...G({tag:"div"}),...q()},"VProgressCircular"),Ut=T()({name:"VProgressCircular",props:Ht(),setup(e,t){let{slots:a}=t;const n=20,s=2*Math.PI*n,l=oe(),{themeClasses:o}=H(e),{sizeClasses:c,sizeStyles:d}=ve(e),{textColorClasses:b,textColorStyles:y}=j(w(e,"color")),{textColorClasses:m,textColorStyles:i}=j(w(e,"bgColor")),{intersectionRef:v,isIntersecting:g}=Ae(),{resizeRef:r,contentRect:h}=bt(),C=u(()=>Math.max(0,Math.min(100,parseFloat(e.modelValue)))),L=u(()=>Number(e.width)),P=u(()=>d.value?Number(e.size):h.value?h.value.width:Math.max(L.value,32)),x=u(()=>n/(1-L.value/P.value)*2),E=u(()=>L.value/P.value*x.value),B=u(()=>S((100-C.value)/100*s));return yt(()=>{v.value=l.value,r.value=l.value}),D(()=>f(e.tag,{ref:l,class:["v-progress-circular",{"v-progress-circular--indeterminate":!!e.indeterminate,"v-progress-circular--visible":g.value,"v-progress-circular--disable-shrink":e.indeterminate==="disable-shrink"},o.value,c.value,b.value,e.class],style:[d.value,y.value,e.style],role:"progressbar","aria-valuemin":"0","aria-valuemax":"100","aria-valuenow":e.indeterminate?void 0:C.value},{default:()=>[f("svg",{style:{transform:`rotate(calc(-90deg + ${Number(e.rotate)}deg))`},xmlns:"http://www.w3.org/2000/svg",viewBox:`0 0 ${x.value} ${x.value}`},[f("circle",{class:["v-progress-circular__underlay",m.value],style:i.value,fill:"transparent",cx:"50%",cy:"50%",r:n,"stroke-width":E.value,"stroke-dasharray":s,"stroke-dashoffset":0},null),f("circle",{class:"v-progress-circular__overlay",fill:"transparent",cx:"50%",cy:"50%",r:n,"stroke-width":E.value,"stroke-dasharray":s,"stroke-dashoffset":B.value},null)]),a.default&&f("div",{class:"v-progress-circular__content"},[a.default({value:C.value})])]})),{}}}),Ce={center:"center",top:"bottom",bottom:"top",left:"right",right:"left"},De=k({location:String},"location");function Fe(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:!1,a=arguments.length>2?arguments[2]:void 0;const{isRtl:n}=Ie();return{locationStyles:u(()=>{if(!e.location)return{};const{side:l,align:o}=Lt(e.location.split(" ").length>1?e.location:`${e.location} center`,n.value);function c(b){return a?a(b):0}const d={};return l!=="center"&&(t?d[Ce[l]]=`calc(100% - ${c(l)}px)`:d[l]=0),o!=="center"?t?d[Ce[o]]=`calc(100% - ${c(o)}px)`:d[o]=0:(l==="center"?d.top=d.left="50%":d[{top:"left",bottom:"left",left:"top",right:"top"}[l]]="50%",d.transform={top:"translateX(-50%)",bottom:"translateX(-50%)",left:"translateY(-50%)",right:"translateY(-50%)",center:"translate(-50%, -50%)"}[l]),d})}}const Xt=k({absolute:Boolean,active:{type:Boolean,default:!0},bgColor:String,bgOpacity:[Number,String],bufferValue:{type:[Number,String],default:0},bufferColor:String,bufferOpacity:[Number,String],clickable:Boolean,color:String,height:{type:[Number,String],default:4},indeterminate:Boolean,max:{type:[Number,String],default:100},modelValue:{type:[Number,String],default:0},opacity:[Number,String],reverse:Boolean,stream:Boolean,striped:Boolean,roundedBar:Boolean,...A(),...De({location:"top"}),...ue(),...G(),...q()},"VProgressLinear"),jt=T()({name:"VProgressLinear",props:Xt(),emits:{"update:modelValue":e=>!0},setup(e,t){var I;let{slots:a}=t;const n=xe(e,"modelValue"),{isRtl:s,rtlClasses:l}=Ie(),{themeClasses:o}=H(e),{locationStyles:c}=Fe(e),{textColorClasses:d,textColorStyles:b}=j(e,"color"),{backgroundColorClasses:y,backgroundColorStyles:m}=J(u(()=>e.bgColor||e.color)),{backgroundColorClasses:i,backgroundColorStyles:v}=J(u(()=>e.bufferColor||e.bgColor||e.color)),{backgroundColorClasses:g,backgroundColorStyles:r}=J(e,"color"),{roundedClasses:h}=ce(e),{intersectionRef:C,isIntersecting:L}=Ae(),P=u(()=>parseFloat(e.max)),x=u(()=>parseFloat(e.height)),E=u(()=>me(parseFloat(e.bufferValue)/P.value*100,0,100)),B=u(()=>me(parseFloat(n.value)/P.value*100,0,100)),N=u(()=>s.value!==e.reverse),W=u(()=>e.indeterminate?"fade-transition":"slide-x-transition"),R=Ct&&((I=window.matchMedia)==null?void 0:I.call(window,"(forced-colors: active)").matches);function _(V){if(!C.value)return;const{left:U,right:X,width:z}=C.value.getBoundingClientRect(),We=N.value?z-V.clientX+(X-z):V.clientX-U;n.value=Math.round(We/z*P.value)}return D(()=>f(e.tag,{ref:C,class:["v-progress-linear",{"v-progress-linear--absolute":e.absolute,"v-progress-linear--active":e.active&&L.value,"v-progress-linear--reverse":N.value,"v-progress-linear--rounded":e.rounded,"v-progress-linear--rounded-bar":e.roundedBar,"v-progress-linear--striped":e.striped},h.value,o.value,l.value,e.class],style:[{bottom:e.location==="bottom"?0:void 0,top:e.location==="top"?0:void 0,height:e.active?S(x.value):0,"--v-progress-linear-height":S(x.value),...e.absolute?c.value:{}},e.style],role:"progressbar","aria-hidden":e.active?"false":"true","aria-valuemin":"0","aria-valuemax":e.max,"aria-valuenow":e.indeterminate?void 0:B.value,onClick:e.clickable&&_},{default:()=>[e.stream&&f("div",{key:"stream",class:["v-progress-linear__stream",d.value],style:{...b.value,[N.value?"left":"right"]:S(-x.value),borderTop:`${S(x.value/2)} dotted`,opacity:parseFloat(e.bufferOpacity),top:`calc(50% - ${S(x.value/4)})`,width:S(100-E.value,"%"),"--v-progress-linear-stream-to":S(x.value*(N.value?1:-1))}},null),f("div",{class:["v-progress-linear__background",R?void 0:y.value],style:[m.value,{opacity:parseFloat(e.bgOpacity),width:e.stream?0:void 0}]},null),f("div",{class:["v-progress-linear__buffer",R?void 0:i.value],style:[v.value,{opacity:parseFloat(e.bufferOpacity),width:S(E.value,"%")}]},null),f(kt,{name:W.value},{default:()=>[e.indeterminate?f("div",{class:"v-progress-linear__indeterminate"},[["long","short"].map(V=>f("div",{key:V,class:["v-progress-linear__indeterminate",V,R?void 0:g.value],style:r.value},null))]):f("div",{class:["v-progress-linear__determinate",R?void 0:g.value],style:[r.value,{width:S(B.value,"%")}]},null)]}),a.default&&f("div",{class:"v-progress-linear__content"},[a.default({value:B.value,buffer:E.value})])]})),{}}}),Yt=k({loading:[Boolean,String]},"loader");function Wt(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:$();return{loaderClasses:u(()=>({[`${t}--loading`]:e.loading}))}}function fn(e,t){var n;let{slots:a}=t;return f("div",{class:`${e.name}__loader`},[((n=a.default)==null?void 0:n.call(a,{color:e.color,isActive:e.active}))||f(jt,{absolute:e.absolute,active:e.active,color:e.color,height:"2",indeterminate:!0},null)])}const Kt=["static","relative","fixed","absolute","sticky"],Jt=k({position:{type:String,validator:e=>Kt.includes(e)}},"position");function Qt(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:$();return{positionClasses:u(()=>e.position?`${t}--${e.position}`:void 0)}}function Zt(){const e=se("useRoute");return u(()=>{var t;return(t=e==null?void 0:e.proxy)==null?void 0:t.$route})}function en(e,t){var b,y;const a=St("RouterLink"),n=u(()=>!!(e.href||e.to)),s=u(()=>(n==null?void 0:n.value)||ge(t,"click")||ge(e,"click"));if(typeof a=="string"||!("useLink"in a))return{isLink:n,isClickable:s,href:w(e,"href")};const l=u(()=>({...e,to:w(()=>e.to||"")})),o=a.useLink(l.value),c=u(()=>e.to?o:void 0),d=Zt();return{isLink:n,isClickable:s,route:(b=c.value)==null?void 0:b.route,navigate:(y=c.value)==null?void 0:y.navigate,isActive:u(()=>{var m,i,v;return c.value?e.exact?d.value?((v=c.value.isExactActive)==null?void 0:v.value)&&Be(c.value.route.value.query,d.value.query):((i=c.value.isExactActive)==null?void 0:i.value)??!1:((m=c.value.isActive)==null?void 0:m.value)??!1:!1}),href:u(()=>{var m;return e.to?(m=c.value)==null?void 0:m.route.value.href:e.href})}}const tn=k({href:String,replace:Boolean,to:[String,Object],exact:Boolean},"router");function nn(e,t){ie(()=>{var a;return(a=e.isActive)==null?void 0:a.value},a=>{e.isLink.value&&a&&t&&_t(()=>{t(!0)})},{immediate:!0})}const ne=Symbol("rippleStop"),an=80;function ke(e,t){e.style.transform=t,e.style.webkitTransform=t}function ae(e){return e.constructor.name==="TouchEvent"}function Me(e){return e.constructor.name==="KeyboardEvent"}const sn=function(e,t){var m;let a=arguments.length>2&&arguments[2]!==void 0?arguments[2]:{},n=0,s=0;if(!Me(e)){const i=t.getBoundingClientRect(),v=ae(e)?e.touches[e.touches.length-1]:e;n=v.clientX-i.left,s=v.clientY-i.top}let l=0,o=.3;(m=t._ripple)!=null&&m.circle?(o=.15,l=t.clientWidth/2,l=a.center?l:l+Math.sqrt((n-l)**2+(s-l)**2)/4):l=Math.sqrt(t.clientWidth**2+t.clientHeight**2)/2;const c=`${(t.clientWidth-l*2)/2}px`,d=`${(t.clientHeight-l*2)/2}px`,b=a.center?c:`${n-l}px`,y=a.center?d:`${s-l}px`;return{radius:l,scale:o,x:b,y,centerX:c,centerY:d}},Y={show(e,t){var v;let a=arguments.length>2&&arguments[2]!==void 0?arguments[2]:{};if(!((v=t==null?void 0:t._ripple)!=null&&v.enabled))return;const n=document.createElement("span"),s=document.createElement("span");n.appendChild(s),n.className="v-ripple__container",a.class&&(n.className+=` ${a.class}`);const{radius:l,scale:o,x:c,y:d,centerX:b,centerY:y}=sn(e,t,a),m=`${l*2}px`;s.className="v-ripple__animation",s.style.width=m,s.style.height=m,t.appendChild(n);const i=window.getComputedStyle(t);i&&i.position==="static"&&(t.style.position="relative",t.dataset.previousPosition="static"),s.classList.add("v-ripple__animation--enter"),s.classList.add("v-ripple__animation--visible"),ke(s,`translate(${c}, ${d}) scale3d(${o},${o},${o})`),s.dataset.activated=String(performance.now()),setTimeout(()=>{s.classList.remove("v-ripple__animation--enter"),s.classList.add("v-ripple__animation--in"),ke(s,`translate(${b}, ${y}) scale3d(1,1,1)`)},0)},hide(e){var l;if(!((l=e==null?void 0:e._ripple)!=null&&l.enabled))return;const t=e.getElementsByClassName("v-ripple__animation");if(t.length===0)return;const a=t[t.length-1];if(a.dataset.isHiding)return;a.dataset.isHiding="true";const n=performance.now()-Number(a.dataset.activated),s=Math.max(250-n,0);setTimeout(()=>{a.classList.remove("v-ripple__animation--in"),a.classList.add("v-ripple__animation--out"),setTimeout(()=>{var c;e.getElementsByClassName("v-ripple__animation").length===1&&e.dataset.previousPosition&&(e.style.position=e.dataset.previousPosition,delete e.dataset.previousPosition),((c=a.parentNode)==null?void 0:c.parentNode)===e&&e.removeChild(a.parentNode)},300)},s)}};function Ge(e){return typeof e>"u"||!!e}function F(e){const t={},a=e.currentTarget;if(!(!(a!=null&&a._ripple)||a._ripple.touched||e[ne])){if(e[ne]=!0,ae(e))a._ripple.touched=!0,a._ripple.isTouch=!0;else if(a._ripple.isTouch)return;if(t.center=a._ripple.centered||Me(e),a._ripple.class&&(t.class=a._ripple.class),ae(e)){if(a._ripple.showTimerCommit)return;a._ripple.showTimerCommit=()=>{Y.show(e,a,t)},a._ripple.showTimer=window.setTimeout(()=>{var n;(n=a==null?void 0:a._ripple)!=null&&n.showTimerCommit&&(a._ripple.showTimerCommit(),a._ripple.showTimerCommit=null)},an)}else Y.show(e,a,t)}}function Se(e){e[ne]=!0}function p(e){const t=e.currentTarget;if(t!=null&&t._ripple){if(window.clearTimeout(t._ripple.showTimer),e.type==="touchend"&&t._ripple.showTimerCommit){t._ripple.showTimerCommit(),t._ripple.showTimerCommit=null,t._ripple.showTimer=window.setTimeout(()=>{p(e)});return}window.setTimeout(()=>{t._ripple&&(t._ripple.touched=!1)}),Y.hide(t)}}function qe(e){const t=e.currentTarget;t!=null&&t._ripple&&(t._ripple.showTimerCommit&&(t._ripple.showTimerCommit=null),window.clearTimeout(t._ripple.showTimer))}let M=!1;function He(e){!M&&(e.keyCode===he.enter||e.keyCode===he.space)&&(M=!0,F(e))}function Ue(e){M=!1,p(e)}function Xe(e){M&&(M=!1,p(e))}function je(e,t,a){const{value:n,modifiers:s}=t,l=Ge(n);if(l||Y.hide(e),e._ripple=e._ripple??{},e._ripple.enabled=l,e._ripple.centered=s.center,e._ripple.circle=s.circle,pt(n)&&n.class&&(e._ripple.class=n.class),l&&!a){if(s.stop){e.addEventListener("touchstart",Se,{passive:!0}),e.addEventListener("mousedown",Se);return}e.addEventListener("touchstart",F,{passive:!0}),e.addEventListener("touchend",p,{passive:!0}),e.addEventListener("touchmove",qe,{passive:!0}),e.addEventListener("touchcancel",p),e.addEventListener("mousedown",F),e.addEventListener("mouseup",p),e.addEventListener("mouseleave",p),e.addEventListener("keydown",He),e.addEventListener("keyup",Ue),e.addEventListener("blur",Xe),e.addEventListener("dragstart",p,{passive:!0})}else!l&&a&&Ye(e)}function Ye(e){e.removeEventListener("mousedown",F),e.removeEventListener("touchstart",F),e.removeEventListener("touchend",p),e.removeEventListener("touchmove",qe),e.removeEventListener("touchcancel",p),e.removeEventListener("mouseup",p),e.removeEventListener("mouseleave",p),e.removeEventListener("keydown",He),e.removeEventListener("keyup",Ue),e.removeEventListener("dragstart",p),e.removeEventListener("blur",Xe)}function ln(e,t){je(e,t,!1)}function on(e){delete e._ripple,Ye(e)}function rn(e,t){if(t.value===t.oldValue)return;const a=Ge(t.oldValue);je(e,t,a)}const un={mounted:ln,unmounted:on,updated:rn},cn=k({active:{type:Boolean,default:void 0},baseColor:String,symbol:{type:null,default:Oe},flat:Boolean,icon:[Boolean,String,Function,Object],prependIcon:te,appendIcon:te,block:Boolean,readonly:Boolean,slim:Boolean,stacked:Boolean,ripple:{type:[Boolean,Object],default:!0},text:String,...Ve(),...A(),...Te(),...xt(),...Pe(),...zt(),...Yt(),...De(),...Jt(),...ue(),...tn(),...de(),...G({tag:"button"}),...q(),...Ne({variant:"elevated"})},"VBtn"),mn=T()({name:"VBtn",props:cn(),emits:{"group:selected":e=>!0},setup(e,t){let{attrs:a,slots:n}=t;const{themeClasses:s}=H(e),{borderClasses:l}=Le(e),{densityClasses:o}=$e(e),{dimensionStyles:c}=wt(e),{elevationClasses:d}=Ee(e),{loaderClasses:b}=Wt(e),{locationStyles:y}=Fe(e),{positionClasses:m}=Qt(e),{roundedClasses:i}=ce(e),{sizeClasses:v,sizeStyles:g}=ve(e),r=Ot(e,e.symbol,!1),h=en(e,a),C=u(()=>{var _;return e.active!==void 0?e.active:h.isLink.value?(_=h.isActive)==null?void 0:_.value:r==null?void 0:r.isSelected.value}),L=u(()=>{var I,V;return{color:(r==null?void 0:r.isSelected.value)&&(!h.isLink.value||((I=h.isActive)==null?void 0:I.value))||!r||((V=h.isActive)==null?void 0:V.value)?e.color??e.baseColor:e.baseColor,variant:e.variant}}),{colorClasses:P,colorStyles:x,variantClasses:E}=Nt(L),B=u(()=>(r==null?void 0:r.disabled.value)||e.disabled),N=u(()=>e.variant==="elevated"&&!(e.disabled||e.flat||e.border)),W=u(()=>{if(!(e.value===void 0||typeof e.value=="symbol"))return Object(e.value)===e.value?JSON.stringify(e.value,null,0):e.value});function R(_){var I;B.value||h.isLink.value&&(_.metaKey||_.ctrlKey||_.shiftKey||_.button!==0||a.target==="_blank")||((I=h.navigate)==null||I.call(h,_),r==null||r.toggle())}return nn(h,r==null?void 0:r.select),D(()=>{const _=h.isLink.value?"a":e.tag,I=!!(e.prependIcon||n.prepend),V=!!(e.appendIcon||n.append),U=!!(e.icon&&e.icon!==!0);return Bt(f(_,{type:_==="a"?void 0:"button",class:["v-btn",r==null?void 0:r.selectedClass.value,{"v-btn--active":C.value,"v-btn--block":e.block,"v-btn--disabled":B.value,"v-btn--elevated":N.value,"v-btn--flat":e.flat,"v-btn--icon":!!e.icon,"v-btn--loading":e.loading,"v-btn--readonly":e.readonly,"v-btn--slim":e.slim,"v-btn--stacked":e.stacked},s.value,l.value,P.value,o.value,d.value,b.value,m.value,i.value,v.value,E.value,e.class],style:[x.value,c.value,y.value,g.value,e.style],"aria-busy":e.loading?!0:void 0,disabled:B.value||void 0,href:h.href.value,tabindex:e.loading||e.readonly?-1:void 0,onClick:R,value:W.value},{default:()=>{var X;return[$t(!0,"v-btn"),!e.icon&&I&&f("span",{key:"prepend",class:"v-btn__prepend"},[n.prepend?f(K,{key:"prepend-defaults",disabled:!e.prependIcon,defaults:{VIcon:{icon:e.prependIcon}}},n.prepend):f(Q,{key:"prepend-icon",icon:e.prependIcon},null)]),f("span",{class:"v-btn__content","data-no-activator":""},[!n.default&&U?f(Q,{key:"content-icon",icon:e.icon},null):f(K,{key:"content-defaults",disabled:!U,defaults:{VIcon:{icon:e.icon}}},{default:()=>{var z;return[((z=n.default)==null?void 0:z.call(n))??e.text]}})]),!e.icon&&V&&f("span",{key:"append",class:"v-btn__append"},[n.append?f(K,{key:"append-defaults",disabled:!e.appendIcon,defaults:{VIcon:{icon:e.appendIcon}}},n.append):f(Q,{key:"append-icon",icon:e.appendIcon},null)]),!!e.loading&&f("span",{key:"loader",class:"v-btn__loader"},[((X=n.loader)==null?void 0:X.call(n))??f(Ut,{color:typeof e.loading=="boolean"?void 0:e.loading,indeterminate:!0,width:"2"},null)])]}}),[[un,!B.value&&!!e.ripple,"",{center:!!e.icon}]])}),{group:r}}});export{fn as L,K as V,ce as a,Ve as b,Pe as c,Le as d,Ee as e,mn as f,Q as g,Te as h,Rt as i,$e as j,At as k,Oe as l,ue as m,vn as n,De as o,Jt as p,Ne as q,Nt as r,Fe as s,Qt as t,J as u,j as v,$t as w,Yt as x,Wt as y};