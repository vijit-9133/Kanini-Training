
function fetchCourseData() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            const courses = [
                {
                    id: 'webdev-mern',
                    title: 'Full Stack Web Development (MERN)',
                    image: 'https://www.keycdn.com/img/support/full-stack-development.png',
                    description: 'Build robust web applications using MongoDB, Express.js, React, and Node.js. Industry-ready skills for the Indian market.',
                    instructor: 'Arjun Reddy',
                    duration: '16 weeks',
                    price: '₹ 25,000',
                    link: 'course-details-mern.html'
                },
                {
                    id: 'data-science',
                    title: 'Applied Data Science with Python',
                    image: 'https://online.umich.edu/media/36941bf4e40f8ab2fd76888ff8d900db.png',
                    description: 'Master data analysis, machine learning, and visualization. Real-world case studies and projects relevant to Indian industries.',
                    instructor: 'Priya Sharma',
                    duration: '14 weeks',
                    price: '₹ 22,500',
                    link: 'course-details-datasci.html'
                },
                {
                    id: 'ux-ui',
                    title: 'UX/UI Design Fundamentals',
                    image: 'https://www.ducatindia.com/_next/image?url=https%3A%2F%2Fadmin.ducatindia.com%2Fblog%2F1737465366012ui-ux-design-portfolio.jpg&w=750&q=75',
                    description: 'Create intuitive and user-friendly interfaces. Learn design principles, wireframing, and prototyping in a practical approach.',
                    instructor: 'Rohan Gupta',
                    duration: '10 weeks',
                    price: '₹ 18,000',
                    link: 'course-details-uxui.html'
                },
                {
                    id: 'android-dev',
                    title: 'Android App Development with Kotlin',
                    image: 'https://mdevelopers.com/storage/0_flickit_5c2d2c75.webp',
                    description: 'Develop native Android applications from scratch using Kotlin. Learn to publish your app on Google Play India.',
                    instructor: 'Sneha Patel',
                    duration: '12 weeks',
                    price: '₹ 20,000',
                    link: 'course-details-android.html'
                },
                {
                    id: 'cloud-aws',
                    title: 'AWS Cloud Practitioner Prep',
                    image: 'https://hystax.com/wp-content/uploads/2024/01/Advantages-and-limitations-of-embracing-AWS-as-a-cloud-infrastructure-1200x675.webp',
                    description: 'Prepare for the AWS Certified Cloud Practitioner exam. Understand core AWS services and cloud architecture.',
                    instructor: 'Vikram Singh',
                    duration: '8 weeks',
                    price: '₹ 15,000',
                    link: 'course-details-aws.html'
                },
                {
                    id: 'digital-marketing',
                    title: 'Advanced Digital Marketing',
                    image: 'https://www.reliablesoft.net/images/free-digital-marketing-training.webp',
                    description: 'Master SEO, SEM, Social Media Marketing, and Content Strategy. Boost your online presence and career in India.',
                    instructor: 'Anjali Rao',
                    duration: '9 weeks',
                    price: '₹ 16,500',
                    link: 'course-details-digital.html'
                },
                {
                    id: 'ethical-hacking',
                    title: 'Certified Ethical Hacking (CEH)',
                    image:'https://specials-images.forbesimg.com/imageserve/67ec0025d8854be78bc70986/Ethical-hacking-concept-with-faceless-hooded-male-person/960x0.jpg?fit=scale',
                    description: 'Learn ethical hacking techniques and penetration testing to secure systems and networks. Hands-on labs included.',
                    instructor: 'Kabir Khan',
                    duration: '10 weeks',
                    price: '₹ 28,000',
                    link: 'course-details-ceh.html'
                },
                {
                    id: 'spoken-english',
                    title: 'Professional Spoken English',
                    image: 'https://knowxbox.com/blogs/wp-content/uploads/2024/06/Get-Ahead-in-English-Communication-with-These-Tips-and-Tricks-from-Top-Spoken-English-Classes.png',
                    description: 'Improve your fluency, pronunciation, and confidence in professional English communication, essential for global careers.',
                    instructor: 'Meena Devi',
                    duration: '6 weeks',
                    price: '₹ 8,000',
                    link: 'course-details-english.html'
                }
            ];
            resolve(courses);
            reject(console.log("Not working"))
        }, 500); 
    });
}

function createCourseCardHtml(course) {
    return `
        <div class="col">
            <div class="card h-100 shadow-sm">
                <img src="${course.image}" class="card-img-top" alt="Course: ${course.title}">
                <div class="card-body d-flex flex-column">
                    <h5 class="card-title">${course.title}</h5>
                    <p class="card-text">${course.description}</p>
                    <ul class="list-group list-group-flush mt-auto">
                        <li class="list-group-item"><strong>Instructor:</strong> ${course.instructor}</li>
                        <li class="list-group-item"><strong>Duration:</strong> ${course.duration}</li>
                        <li class="list-group-item"><strong>Price:</strong> ${course.price}</li>
                    </ul>
                    <a href="${course.link}" class="btn btn-primary mt-3">View Details</a>
                </div>
            </div>
        </div>
    `;
}


function renderAllCoursesInCarousel() {
    const courseCardsCarouselInner = document.getElementById('courseCardsCarouselInner');
    const courseCarouselIndicators = document.getElementById('courseCarouselIndicators');
    const cardsPerSlide = 4;

    if (!courseCardsCarouselInner || !courseCarouselIndicators) {
        console.error('Error: Course carousel containers not found in the DOM.');
        return;
    }

    courseCardsCarouselInner.innerHTML = '<p class="text-center w-100 text-muted">Loading courses...</p>';
    courseCarouselIndicators.innerHTML = ''; 

    fetchCourseData()
        .then(courses => {
            courseCardsCarouselInner.innerHTML = ''; 

            for (let i = 0; i < courses.length; i += cardsPerSlide) {
                const chunk = courses.slice(i, i + cardsPerSlide);
                const isActive = (i === 0) ? 'active' : '';

                const carouselItemDiv = document.createElement('div');
                carouselItemDiv.className = `carousel-item ${isActive}`;

                
                const rowDiv = document.createElement('div');
                rowDiv.className = 'row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 g-4';

                
                chunk.forEach(course => {
                    rowDiv.innerHTML += createCourseCardHtml(course);
                });

                carouselItemDiv.appendChild(rowDiv);
                courseCardsCarouselInner.appendChild(carouselItemDiv);

                const indicatorButton = document.createElement('button');
                indicatorButton.type = 'button';
                indicatorButton.setAttribute('data-bs-target', '#courseCardsCarousel');
                indicatorButton.setAttribute('data-bs-slide-to', i / cardsPerSlide);
                indicatorButton.setAttribute('aria-label', `Slide ${i / cardsPerSlide + 1}`);
                if (isActive) {
                    indicatorButton.classList.add('active');
                    indicatorButton.setAttribute('aria-current', 'true');
                }
                courseCarouselIndicators.appendChild(indicatorButton);
            }
        })
        .catch(error => {
            console.error('Error fetching course data:', error);
            courseCardsCarouselInner.innerHTML = '<p class="text-danger text-center w-100">Failed to load courses. Please try again later.</p>';
        });
}

document.addEventListener('DOMContentLoaded', renderAllCoursesInCarousel);