import React from 'react';
import { render, screen } from '@testing-library/react';
import Header from './header';

test('renders fraks garage brand', () => {
  render(<Header />);
  const linkElement = screen.getByText(/Frank's Garage/i);
  expect(linkElement).toBeInTheDocument();
});
