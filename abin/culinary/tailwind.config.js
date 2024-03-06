/** @type {import('tailwindcss').Config} */
export default {
  content: [  
    "./index.html",
  "./src/**/*.{vue,js,ts,jsx,tsx}",
],
  theme: {
    extend: {
    //   daisyui: {
    //     themes: ["light", "dark", "bumblebee"],
    //  },
      colors:{
        dark: '#272343',
        tertier:'#bae8e8',
        highlight:'#ffd803',
      }
    },
  },
  // plugins: [("daisyui")],
}

