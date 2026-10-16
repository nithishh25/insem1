
let courses = [
    {
        name: "Java Programming",
        instructor: "Rahul",
        duration: 30
    },
    {
        name: "Web Development",
        instructor: "Priya",
        duration: 25
    },
    {
        name: "Python Programming",
        instructor: "Arun",
        duration: 20
    }
];

// Display available courses
function displayCourses() {
    const courseList = document.getElementById("courseList");
    const search = document.getElementById("searchInput")
        .value.toLowerCase();

    courseList.innerHTML = "";

    const filteredCourses = courses.filter(course =>
        course.name.toLowerCase().includes(search) ||
        course.instructor.toLowerCase().includes(search)
    );

    if (filteredCourses.length === 0) {
        courseList.innerHTML = "<p>No courses found.</p>";
        return;
    }

    filteredCourses.forEach(course => {
        const card = document.createElement("div");
        card.className = "course-card";

        const title = document.createElement("h3");
        title.textContent = course.name;

        const teacher = document.createElement("p");
        teacher.textContent = "Instructor: " + course.instructor;

        const duration = document.createElement("p");
        duration.textContent = "Duration: " + course.duration + " hours";

        const enrollButton = document.createElement("button");
        enrollButton.textContent = "Enroll Now";

        enrollButton.addEventListener("click", function () {
            alert("You have enrolled in " + course.name + "!");
        });

        card.append(title, teacher, duration, enrollButton);
        courseList.appendChild(card);
    });
}

// Add a new course
document.getElementById("courseForm").addEventListener(
    "submit",
    function (event) {
        event.preventDefault();

        const name = document.getElementById("courseName")
            .value.trim();

        const instructor = document.getElementById("instructor")
            .value.trim();

        const duration = Number(
            document.getElementById("duration").value
        );

        if (!name || !instructor || !Number.isFinite(duration) ||
            duration < 1) {
            document.getElementById("message").textContent =
                "Please enter valid course details.";
            return;
        }

        courses.push({
            name: name,
            instructor: instructor,
            duration: duration
        });

        document.getElementById("message").textContent =
            "Course added successfully!";

        document.getElementById("courseForm").reset();
        displayCourses();
    }
);

// Initial display
displayCourses();
