import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CertifViewComponent } from './certif-view.component';

describe('CertifViewComponent', () => {
  let component: CertifViewComponent;
  let fixture: ComponentFixture<CertifViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CertifViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CertifViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
