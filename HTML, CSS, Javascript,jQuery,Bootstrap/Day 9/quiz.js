
document.addEventListener('DOMContentLoaded', () => {
    const quizSettingsSection = document.getElementById('quiz-settings');
    const quizDisplaySection = document.getElementById('quiz-display');
    const quizResultsSection = document.getElementById('quiz-results');

    const quizSettingsForm = document.getElementById('quizSettingsForm');
    const quizAmountInput = document.getElementById('quizAmount');
    const quizCategorySelect = document.getElementById('quizCategory');
    const quizDifficultySelect = document.getElementById('quizDifficulty');
    const quizTypeRadios = document.querySelectorAll('input[name="quizType"]');
    const startQuizBtn = document.getElementById('startQuizBtn');
    const quizSettingsMessage = document.getElementById('quizSettingsMessage');

    const currentQuestionNumberSpan = document.getElementById('currentQuestionNumber');
    const totalQuestionsSpan = document.getElementById('totalQuestions');
    const questionTextElement = document.getElementById('questionText');
    const answerOptionsDiv = document.getElementById('answerOptions');
    const quizFeedbackElement = document.getElementById('quizFeedback');
    const nextQuestionBtn = document.getElementById('nextQuestionBtn');

    const finalScoreSpan = document.getElementById('finalScore');
    const maxScoreSpan = document.getElementById('maxScore');
    const playAgainBtn = document.getElementById('playAgainBtn');

    
    let questions = []; 
    let currentQuestionIndex = 0; 
    let score = 0; 

  

    function decodeHtml(html) {
        const txt = document.createElement('textarea');
        txt.innerHTML = html;
        return txt.value;
    }

    function shuffleArray(array) {
        for (let i = array.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [array[i], array[j]] = [array[j], array[i]]; 
        }
        return array;
    }

    function showSettingsMessage(message, type = 'info') {
        quizSettingsMessage.textContent = message;
        quizSettingsMessage.className = `text-center mt-3 text-${type}`;
        quizSettingsMessage.classList.remove('d-none');
    }

    function hideAllQuizSections() {
        quizSettingsSection.classList.add('d-none');
        quizDisplaySection.classList.add('d-none');
        quizResultsSection.classList.add('d-none');
    }

    function showSection(sectionElement) {
        hideAllQuizSections();
        sectionElement.classList.remove('d-none');
    }

    
    async function fetchCategories() {
        try {
            const response = await fetch('https://opentdb.com/api_category.php');
            const data = await response.json();

            if (data && data.trivia_categories) {
                data.trivia_categories.forEach(category => {
                    const option = document.createElement('option');
                    option.value = category.id;
                    option.textContent = category.name;
                    quizCategorySelect.appendChild(option);
                });
            } else {
                showSettingsMessage('Failed to load quiz categories. Invalid data.', 'danger');
                console.error('Failed to fetch categories: Invalid data format.', data);
            }
        } catch (error) {
            showSettingsMessage('Network error: Could not load quiz categories. Check your internet connection.', 'danger');
            console.error('Error fetching categories:', error);
        }
    }

    async function fetchQuestions(amount, category, difficulty, type) {
        let apiUrl = `https://opentdb.com/api.php?amount=${amount}`;
        if (category !== 'any') apiUrl += `&category=${category}`;
        if (difficulty !== 'any') apiUrl += `&difficulty=${difficulty}`;
        if (type !== 'any') apiUrl += `&type=${type}`;

        try {
            const response = await fetch(apiUrl);
            const data = await response.json();

            if (data.response_code === 0 && data.results.length > 0) {
                questions = data.results;
                currentQuestionIndex = 0;
                score = 0;
                totalQuestionsSpan.textContent = questions.length;
                displayQuestion(); 
                showSection(quizDisplaySection); 
            } else {
                let errorMessage = 'No questions found for the selected criteria. Please try different options.';
                if (data.response_code === 1) errorMessage = 'No questions found for the selected criteria.';
                if (data.response_code === 2) errorMessage = 'Invalid parameter. Check quiz settings.';

                showSettingsMessage(errorMessage, 'warning');
                console.warn('API Response Code:', data.response_code, 'Message:', errorMessage);
                showSection(quizSettingsSection); 
            }
        } catch (error) {
            showSettingsMessage('Network error: Could not fetch questions. Check your internet connection.', 'danger');
            console.error('Error fetching questions:', error);
            showSection(quizSettingsSection); 
        }
    }

    function displayQuestion() {
        quizFeedbackElement.textContent = ''; 
        answerOptionsDiv.innerHTML = ''; 
        nextQuestionBtn.classList.add('d-none'); 

        const currentQ = questions[currentQuestionIndex];
        currentQuestionNumberSpan.textContent = currentQuestionIndex + 1;
        questionTextElement.textContent = decodeHtml(currentQ.question);

        const answers = [...currentQ.incorrect_answers, currentQ.correct_answer];
        const shuffledAnswers = shuffleArray(answers);

        shuffledAnswers.forEach(answer => {
            const button = document.createElement('button');
            button.className = 'btn btn-outline-primary mb-2 text-start'; 
            button.textContent = decodeHtml(answer);
            button.setAttribute('data-answer', decodeHtml(answer)); 
            button.addEventListener('click', () => checkAnswer(button));
            answerOptionsDiv.appendChild(button);
        });
    }

    function checkAnswer(selectedButton) {
        Array.from(answerOptionsDiv.children).forEach(button => {
            button.disabled = true;
            button.classList.remove('btn-outline-primary');
        });

        const selectedAnswer = selectedButton.getAttribute('data-answer');
        const correctAnswer = decodeHtml(questions[currentQuestionIndex].correct_answer);

        if (selectedAnswer === correctAnswer) {
            score++;
            quizFeedbackElement.textContent = 'Correct!';
            quizFeedbackElement.classList.remove('text-danger');
            quizFeedbackElement.classList.add('text-success');
            selectedButton.classList.add('btn-success'); 
        } else {
            quizFeedbackElement.textContent = `Incorrect! The correct answer was: ${correctAnswer}`;
            quizFeedbackElement.classList.remove('text-success');
            quizFeedbackElement.classList.add('text-danger');
            selectedButton.classList.add('btn-danger'); 
            Array.from(answerOptionsDiv.children).forEach(button => {
                if (button.getAttribute('data-answer') === correctAnswer) {
                    button.classList.add('btn-info'); 
                }
            });
        }
        nextQuestionBtn.classList.remove('d-none'); 
    }

    function nextQuestion() {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.length) {
            displayQuestion();
        } else {
            displayResults();
        }
    }

    function displayResults() {
        finalScoreSpan.textContent = score;
        maxScoreSpan.textContent = questions.length;
        showSection(quizResultsSection);
    }

    function resetQuiz() {
        questions = [];
        currentQuestionIndex = 0;
        score = 0;
        quizSettingsForm.reset(); 
        showSettingsMessage('Configure your next quiz!', 'info');
        showSection(quizSettingsSection);
    }

    
    quizSettingsForm.addEventListener('submit', (event) => {
        event.preventDefault();
        const amount = parseInt(quizAmountInput.value);
        const category = quizCategorySelect.value;
        const difficulty = quizDifficultySelect.value;
        let type;
        for (const radio of quizTypeRadios) {
            if (radio.checked) {
                type = radio.value;
                break;
            }
        }
        
        if (isNaN(amount) || amount < 1 || amount > 10) {
            showSettingsMessage('Please enter a valid number of questions (1-10).', 'warning');
            return;
        }

        showSettingsMessage('Fetching questions...', 'info');
        fetchQuestions(amount, category, difficulty, type);
    });

    nextQuestionBtn.addEventListener('click', nextQuestion);

    playAgainBtn.addEventListener('click', resetQuiz);

    fetchCategories();
});