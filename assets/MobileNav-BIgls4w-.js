import{p as T,m as I,M as R,g as L,G as w,h as x,Y as D,t as u,P as z,l as s,N as G,Q as M,J as U,i as E,a as o,D as j,c as h,w as t,T as A,o as v,U as r,b as f,W as m,X as F,e as V}from"./index-BHXZjlgr.js";import{b as J,i as Q,c as W,m as X,j as Y,d as q,u as H,k as K,e as O,a as Z,l as $,n as ee,f as te,h as c,g as d}from"./VBtn-DeTcHmdK.js";import{V as p}from"./VSpacer-CwnXq98M.js";/* empty css              */const oe=T({baseColor:String,bgColor:String,color:String,grow:Boolean,mode:{type:String,validator:e=>!e||["horizontal","shift"].includes(e)},height:{type:[Number,String],default:56},active:{type:Boolean,default:!0},...J(),...I(),...Q(),...W(),...X(),...R({name:"bottom-navigation"}),...L({tag:"header"}),...Y({selectedClass:"v-btn--selected"}),...w()},"VBottomNavigation"),ae=x()({name:"VBottomNavigation",props:oe(),emits:{"update:active":e=>!0,"update:modelValue":e=>!0},setup(e,l){let{slots:a}=l;const{themeClasses:n}=D(),{borderClasses:b}=q(e),{backgroundColorClasses:_,backgroundColorStyles:y}=H(u(e,"bgColor")),{densityClasses:k}=K(e),{elevationClasses:C}=O(e),{roundedClasses:B}=Z(e),{ssrBootStyles:i}=z(),g=s(()=>Number(e.height)-(e.density==="comfortable"?8:0)-(e.density==="compact"?16:0)),S=G(e,"active",e.active),{layoutItemStyles:P,layoutIsReady:N}=M({id:e.name,order:s(()=>parseInt(e.order,10)),position:s(()=>"bottom"),layoutSize:s(()=>S.value?g.value:0),elementSize:g,active:S,absolute:u(e,"absolute")});return $(e,ee),U({VBtn:{baseColor:u(e,"baseColor"),color:u(e,"color"),density:u(e,"density"),stacked:s(()=>e.mode!=="horizontal"),variant:"text"}},{scoped:!0}),E(()=>o(e.tag,{class:["v-bottom-navigation",{"v-bottom-navigation--active":S.value,"v-bottom-navigation--grow":e.grow,"v-bottom-navigation--shift":e.mode==="shift"},n.value,_.value,b.value,k.value,C.value,B.value,e.class],style:[y.value,P.value,{height:j(g.value)},i.value,e.style]},{default:()=>[a.default&&o("div",{class:"v-bottom-navigation__content"},[a.default()])]})),N}}),se=m("span",null,"Search",-1),le=m("span",null,"Combat Report",-1),ne=m("span",null,"Logout",-1),ie=m("span",null,"Login",-1),me={__name:"MobileNav",setup(e){const l=A(),a=te(),n=s(()=>a.isLoggedIn),b=s(()=>{var i;return((i=a==null?void 0:a.user)==null?void 0:i.username)??""}),_=()=>{l.push("/profile")},y=()=>{l.push("/search")},k=()=>{l.push("/combat-report")},C=()=>{l.push("/login")},B=()=>{a.logout()};return(i,g)=>(v(),h(ae,{app:"",height:"64",grow:"",mode:"shift"},{default:t(()=>[o(d,{class:"fill-height",onClick:y},{default:t(()=>[o(c,null,{default:t(()=>[r("mdi-book-search")]),_:1}),se]),_:1}),o(p),o(d,{class:"fill-height",onClick:k},{default:t(()=>[o(c,null,{default:t(()=>[r("mdi-file-document-edit")]),_:1}),le]),_:1}),o(p),f(n)?(v(),h(d,{key:0,class:"fill-height",onClick:_},{default:t(()=>[o(c,null,{default:t(()=>[r("mdi-account")]),_:1}),m("span",null,F(f(b)),1)]),_:1})):V("",!0),f(n)?(v(),h(d,{key:1,class:"fill-height",onClick:B},{default:t(()=>[o(c,null,{default:t(()=>[r("mdi-logout")]),_:1}),ne]),_:1})):V("",!0),f(n)?V("",!0):(v(),h(d,{key:2,class:"fill-height",onClick:C},{default:t(()=>[o(c,null,{default:t(()=>[r("mdi-login")]),_:1}),ie]),_:1}))]),_:1}))}};export{me as default};
