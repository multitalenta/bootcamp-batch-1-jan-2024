/** @type {import('tailwindcss').Config} */
export default {
  content: [  
    "./index.html",
  "./src/**/*.{vue,js,ts,jsx,tsx}",
],
  theme: {
    extend: {
      container:{
        center : true,
        padding : '16px',
      },
      colors:{
        tertier:'#bae8e8',
      },
      colors: {
        primary: '#451a03',
        secondary:'#64748b',
        dark: '#0f172a',
        },
        screens:{
          '2xl':'1320px',
        },
  },  
  plugins: [],
},
}
