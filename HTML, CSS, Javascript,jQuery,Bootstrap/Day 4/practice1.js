const Jokes=[
    {
        joke:"Why don't skeletons fight each other? Because they don't have the guts."

    },
    {
        joke: "Why did the scarecrow win an award?Because he was outstanding in his field!"
    },
    {
        joke:"Why did the bicycle fall over?It was two-tired."
    },
    {
        joke:"What do you call fake spaghetti?An impasta."
    },
    {
        joke:"Why can't your nose be 12 inches long?Because then it would be a foot."
    },
    {
        joke:"What do you get when you cross a snowman and a dog?Frostbite."
    },
    {
        joke:"Parallel lines have so much in common...It’s a shame they’ll never meet."
    },
    {
        joke:"What’s orange and sounds like a parrot?A carrot."
    },
    {
        joke:"I told my wife she was drawing her eyebrows too high.She looked surprised."
    },
    { 
        joke:"Why did the coffee file a police report?It got mugged."
    }
]
function Display(){
 const randind= Math.floor(Math.random() * Jokes.length);
 const joke1= Jokes[randind].joke;
 const frame = document.getElementById("myframe");
const frameDoc = frame.contentDocument || frame.contentWindow.document;

  frameDoc.open();
  frameDoc.write(`<body style="font-family: sans-serif; padding: 10px;">😄 Smile: ${joke1}</body>`);
  frameDoc.close();

    

}