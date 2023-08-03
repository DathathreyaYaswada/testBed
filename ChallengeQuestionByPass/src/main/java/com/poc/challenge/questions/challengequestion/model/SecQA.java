package com.poc.challenge.questions.challengequestion.model;

import jakarta.persistence.*;




@Entity
@Table(name = "secqa")
public class SecQA {
	
	 @Id
	 @GeneratedValue(strategy = GenerationType.IDENTITY)
	 private Long seqId;
	 
	 @ManyToOne(fetch = FetchType.EAGER)
	 @JoinColumn(name = "user_id")
	 private User user;
	 
	 @Column(name = "question")
	 private String question;
	 
	 @Column(name = "answer")
	 private String answer;

	public SecQA() {
	}

	public SecQA(User user, String question, String answer) {
		this.user = user;
		this.question = question;
		this.answer = answer;
	}

	public Long getSeqId() {
		return seqId;
	}

	public void setSeqId(Long seqId) {
		this.seqId = seqId;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public String getQuestion() {
		return question;
	}

	public void setQuestion(String question) {
		this.question = question;
	}

	public String getAnswer() {
		return answer;
	}

	public void setAnswer(String answer) {
		this.answer = answer;
	}
}
